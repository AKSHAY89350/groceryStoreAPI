using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        readonly Business_Layer.IDataAccess dataAccess;
        private readonly string DateFormat;
        public ReviewController(Business_Layer.IDataAccess dataAccess, IConfiguration configuration)
        {
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];
        }
        [HttpPost("InsertReview")]
        public IActionResult InsertReview([FromBody] Review review)
        {
            review.CreatedAt = DateTime.Now.ToString(DateFormat);
            dataAccess.InsertReview(review);
            return Ok("inserted");
        }

        [HttpGet("GetProductReviews/{productId}")]
        public IActionResult GetProductReviews(int productId)
        {
            var result = dataAccess.GetProductReviews(productId);
            return Ok(result);
        }
    }
}
