using AutoMapper;
using FlowerReviewApp.Dto;
using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using FlowerReviewApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlowerReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public FlowerController(IFlowerRepository flowerRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _flowerRepository = flowerRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DetailedProduct>))]
        public IActionResult GetFlowers()
        {
            var flowers = _mapper.Map<List<FlowerDto>>(_flowerRepository.GetFlowers());

            return Ok(flowers);
        }

        [HttpGet("{flowerId}")]
        [ProducesResponseType(200, Type = typeof(DetailedProduct))]
        [ProducesResponseType(400)]
        public IActionResult GetFlower(int flowerId)
        {
            if (!_flowerRepository.IsFlowerExists(flowerId))
                return NotFound();
            var flower = _mapper.Map<FlowerDto>(_flowerRepository.GetFlower(flowerId));

            return Ok(flower);
        }

        [HttpGet("{flowerId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetFlowerRating(int flowerId)
        {
            if (!_flowerRepository.IsFlowerExists(flowerId))
                return NotFound();

            var rating = _flowerRepository.GetRating(flowerId);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFlower([FromQuery] int ownerId, [FromBody] FlowerDto flowerCreate)
        {
            if (flowerCreate == null)
                return BadRequest(ModelState);
            var flower = _flowerRepository.GetFlowers()
                .Where(f => f.DetailedProductName.Trim().ToUpper() == flowerCreate.DetailedProductName.TrimEnd().ToUpper())
                .FirstOrDefault();
            if(flower != null)
            {
                ModelState.AddModelError("", "Flower already exists");
                return StatusCode(422, ModelState);
            }    
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var flowerMap = _mapper.Map<DetailedProduct>(flowerCreate);
            flowerMap.CreatedAt = DateTime.UtcNow;
            flowerMap.UpdatedAt = DateTime.UtcNow;
            if (!_flowerRepository.CreateNewFlower(ownerId, flowerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{flowerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFlower(int flowerId, [FromBody] FlowerDto updatedProduct)
        {
            if (updatedProduct == null)
                return BadRequest(ModelState);

            if (flowerId != updatedProduct.DetailedProductId)
                return BadRequest(ModelState);

            if (!_flowerRepository.IsFlowerExists(flowerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var productMap = _mapper.Map<DetailedProduct>(updatedProduct);
            productMap.UpdatedAt = DateTime.UtcNow;

            if (!_flowerRepository.UpdateFlower(productMap))
            {
                ModelState.AddModelError("", "Something went wrong updating flower");
                return StatusCode(500, ModelState);
            }

            return Ok(new
            {
                Success = true, Data = productMap
            });
        }

        [HttpDelete("{flowerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFlower(int flowerId)
        {
            if (!_flowerRepository.IsFlowerExists(flowerId))
            {
                return NotFound();
            }

            var productToDelete = _flowerRepository.GetFlower(flowerId);
            var reviewsToDelete = _reviewRepository.GetReviewOfAFlower(flowerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }
            if (!_flowerRepository.DeleteFlower(productToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting flower");
            }

            return NoContent();
        }
    }
}
