
using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Layer;


namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly Business_Layer.IAdminRepository dataAccess;
        private readonly string DateFormat;
        public AdminController(IAdminRepository dataAccess, IConfiguration configuration)
        {
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];
        }

       /* [HttpPost]
        [Route("api/edit/{id}")]
        public IActionResult EditProduct(int id, AddProduct updatedProduct)
        {
            var rowsAffected = dataAccess.EditProduct(id, updatedProduct);
            return Ok(rowsAffected);
        }*/
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                bool success = dataAccess.DeleteProduct(id);
                if (success)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the product.");

            }
        }


        [HttpPost("AddProduct")]
        public IActionResult PostProduct(AddProduct product)
        {

            dataAccess.AddProduct(product);

            return Ok();


        }
        /*  [HttpPut("Edit/{id}")]
          public IActionResult EditProduct(int id, [FromBody] Product product)
          {
              if (product == null)
              {
                  return BadRequest("Product data is missing.");
              }

              if (id != product.Id)
              {
                  return BadRequest("Invalid product ID.");
              }
              try
              {
                  dataAccess.EditProduct(product);
                  return Ok("Product updated successfully.");
              }
              catch
              {
                  // Handle any exceptions and return an appropriate response
                  return StatusCode(500, "An error occurred while updating the product.");
              }

          }*/
       
       
    }
}
