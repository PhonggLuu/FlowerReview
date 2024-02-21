using AutoMapper;
using FlowerReviewApp.Dto;
using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviews()
        {
            var categories = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            return Ok(categories);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewerId)
        {
            if (!_reviewerRepository.IsReviewerExists(reviewerId))
                return NotFound();

            var review = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

            return Ok(review);
        }

        [HttpGet("reviews/{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewByReviewer(int reviewerId)
        {
            if (!_reviewerRepository.IsReviewerExists(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewByReviewer(reviewerId));

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            if (reviewerCreate == null)
            {
                var errorResponse = new { message = "ReviewerCreate object is null." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }    

            var reviewers = await _reviewerRepository.GetReviewers();
            var reviewer = reviewers
                .Where(c => c.LastName.Trim().ToUpper() == reviewerCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (reviewer != null)
            {
                var errorResponse = new { message = "Reviewer already exists." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToList());

                var errorResponse = new { message = "Model validation failed.", errors = errors };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            var reviewerMap = _mapper.Map<Reviewer>(reviewerCreate);

            if (!_reviewerRepository.CreateReviewer(reviewerMap))
            {
                var errorResponse = new { message = "Something went wrong while saving!" };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            return new JsonResult(reviewerMap);
        }

        [HttpPut("{reviewerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> RemoveProductInCart(int reviewerId, [FromBody] ReviewerDto reviewerUpdate)
        {
            if (reviewerUpdate == null)
            {
                var errorResponse = new { message = "Reviewer does not have infor" };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            if(reviewerId != reviewerUpdate.ReviewerId)
            {
                var errorResponse = new { message = "Id is not matching." };
                return new JsonResult(errorResponse) { StatusCode= StatusCodes.Status400BadRequest };
            }

            if (!ModelState.IsValid)
            {
                var errorResponse = new { message = "Model validation failed." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            var reviewer = _mapper.Map<Reviewer> (reviewerUpdate);
            if (!_reviewerRepository.UpdateReviewer(reviewer))
            {
                var errorResponse = new { message = "Something went wrong while saving!." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            var result = new JsonResult(new
            {
                message = "Update successfully!",
                data = reviewer // yourData là đối tượng mà bạn muốn trả về dưới dạng JSON
            });
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }

        [HttpDelete("{reviewerId}")]
        public async Task<JsonResult> DeleteReviewer(int reviewerId)
        {
            Reviewer reviewer = _reviewerRepository.GetReviewer(reviewerId);
            if (reviewer == null)
            {
                var errorResponse = new { message = "Reviewer does not have infor!." };
                return new JsonResult(errorResponse) { StatusCode = StatusCodes.Status400BadRequest };
            }

            if (!_reviewerRepository.DeleteReviewer(reviewer))
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
