using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly Business_Layer.IDataAccess dataAccess;
        private readonly string DateFormat;
        public LoginController(Business_Layer.IDataAccess dataAccess, IConfiguration configuration)
        {
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];
        }
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            user.CreatedAt = DateTime.Now.ToString(DateFormat);
            user.ModifiedAt = DateTime.Now.ToString(DateFormat);

            var result = dataAccess.InsertUser(user);

            string? message;
            if (result) message = "Register Successfully";
            else message = "Already register";
            return Ok(message);
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] User user)
        {
            var token = dataAccess.IsUserPresent(user.Email, user.Password);
            if (token == "") token = "invalid";
            return Ok(token);
        }
    }
}
