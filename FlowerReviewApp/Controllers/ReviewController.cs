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
    public class ReviewController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewController(IFlowerRepository flowerRepository, IReviewerRepository reviewerRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _flowerRepository = flowerRepository;
            _reviewerRepository = reviewerRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var categories = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            return Ok(categories);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.HasReview(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));

            return Ok(review);
        }

        [HttpGet("reviews/{flowerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewOfAFlower(int flowerId)
        {
            if (!_reviewRepository.HasReview(flowerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewOfAFlower(flowerId));

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int flowerId, [FromBody] ReviewDto reviewCreate)
        {
            if (reviewCreate == null)
                return BadRequest(ModelState);

            var isExisted = _reviewRepository.GetReviews().Any(c => c.Title.Trim().ToUpper() == reviewCreate.Title.Trim().ToUpper());
            if (isExisted)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(reviewCreate);

            reviewMap.DetailedProduct = _flowerRepository.GetFlower(flowerId);
            reviewMap.Reviewer = _reviewerRepository.GetReviewer(reviewerId);


            if (!_reviewRepository.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{reviewId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> RemoveProductInCart(int reviewId, [FromBody] ReviewDto reviewUpdate)
        {
            if (reviewUpdate == null)
            {
                var errorResponse = new { message = "Review does not have infor" };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            if (reviewId != reviewUpdate.ReviewId)
            {
                var errorResponse = new { message = "Id is not matching." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            if (!ModelState.IsValid)
            {
                var errorResponse = new { message = "Model validation failed." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            var review = _mapper.Map<Review>(reviewUpdate);
            if (!_reviewRepository.UpdateReview(review))
            {
                var errorResponse = new { message = "Something went wrong while saving!." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            var result = new JsonResult(new
            {
                message = "Update successfully!",
                data = review // yourData là đối tượng mà bạn muốn trả về dưới dạng JSON
            });
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }

        [HttpDelete("{reviewId}")]
        public async Task<JsonResult> DeleteReview(int reviewId)
        {
            Review review = _reviewRepository.GetReview(reviewId);
            if (review == null)
            {
                var errorResponse = new { message = "Reviewer does not have infor!." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            if (!_reviewRepository.DeleteReview(review))
            {
                var errorResponse = new { message = "Something went wrong while saving!." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            var result = new JsonResult(new
            {
                message = "Deleted successfully!",
            });
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }
    }
}
