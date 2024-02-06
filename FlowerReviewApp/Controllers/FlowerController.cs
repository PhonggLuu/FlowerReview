using AutoMapper;
using FlowerReviewApp.Dto;
using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly IMapper _mapper;
        public FlowerController(IFlowerRepository flowerRepository, IMapper mapper)
        {
            _flowerRepository = flowerRepository;
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
    }
}
