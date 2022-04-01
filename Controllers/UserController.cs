using Microsoft.AspNetCore.Mvc;
using TuChance.Interfaces;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using TuChance.Payloads;

namespace TuChance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("")]
        public IActionResult CreateUser(CreateUserPayload model)
        {
            try
            {
                var response = _userService.CreateUser(model);
                if (response != null) { return Ok(new { data = response, message = "the user was created successfully" }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }

            return Unauthorized(new { data = new { }, message = "the email entered already exists"});
        }
    }
}
