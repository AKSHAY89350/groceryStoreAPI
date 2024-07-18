using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        readonly Business_Layer.IDataAccess dataAccess;
        private readonly string DateFormat;
        public CartController(Business_Layer.IDataAccess dataAccess, IConfiguration configuration)
        {
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];

        }
        [HttpPost("InsertCartItem/{userid}/{productid}")]
        public IActionResult InsertCartItem(int userid, int productid)
        {
            var result = dataAccess.InsertCartItem(userid, productid);
            return Ok(result ? "inserted" : "not inserted");
        }

        [HttpGet("GetActiveCartOfUser/{id}")]
        public IActionResult GetActiveCartOfUser(int id)
        {
            var result = dataAccess.GetActiveCartOfUser(id);
            return Ok(result);
        }

        [HttpPut("UpdateCart/{cartItemId}/{newQuantity}")]
        public IActionResult UpdateCart(int cartItemId, int newQuantity)
        {
            bool updated = dataAccess.UpdateCartItem(cartItemId, newQuantity);
            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("RemoveCartItem/{cartItemId}")]
        public IActionResult RemoveCartItem(int cartItemId)
        {
            bool removed = dataAccess.RemoveCartItem(cartItemId);
            if (removed)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
