using Microsoft.AspNetCore.Mvc;
using TuChance.Interfaces;
using System;
using TuChance.Payloads;
using TuChance.Library;

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
        public IActionResult CreateUser(CreateUserPayload payload)
        {
            try
            {
                var response = _userService.CreateUser(payload);
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
