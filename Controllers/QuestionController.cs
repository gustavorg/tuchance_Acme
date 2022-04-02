using Microsoft.AspNetCore.Mvc;
using TuChance.Interfaces;
using System;
using TuChance.Payloads;
using TuChance.Library;

namespace TuChance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("types")]
        public IActionResult GetQuestionTypes()
        {
            try
            {
                var response = _questionService.GetQuestionTypes();
                if (response != null) { return Ok(new { data = response }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            return Unauthorized(new { data = new { }, message = "error list question types" });
        }
    }
}
