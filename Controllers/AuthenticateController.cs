using Microsoft.AspNetCore.Mvc;
using TuChance.Interfaces;
using Microsoft.Net.Http.Headers;
using System;
using TuChance.Payloads;

namespace TuChance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("")]
        public IActionResult Authenticate(GetAuthenticatePayload payload)
        {
            try
            {
                var response = _authenticateService.Authenticate(payload);
                if (response != null) { return Ok(new { data = response, message = "session started" }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }

            return Unauthorized(new { data = new { }, message = "wrong credentials" });
        }

        [Authorize]
        [HttpGet("seed")]
        public IActionResult GetSeed()
        {
            try
            {
                var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var users = _authenticateService.GetSeed(0,_bearer_token);
                if (users.Id > 0)
                {
                    return Ok(new { data = users, message = ""});
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            return Unauthorized(new { data = new { }, message = "User not found"});
        }
    }
}
