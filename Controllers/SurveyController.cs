using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TuChance.Interfaces;
using System;
using TuChance.Dtos;
using TuChance.Payloads;

namespace TuChance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [Authorize]
        [HttpGet("")]
        public IActionResult GetAll()
        {
            List<GetSurveyDto> response;
            try
            {
                response = _surveyService.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Ok(new { data = response, message = "" });
        }

        [Authorize]
        [HttpPost("")]
        public IActionResult CreateSurvey(CreateSurveyPayload payload)
        {
            try
            {
                var response = _surveyService.CreateSurvey(payload);
                if (response != null) { return Ok(new { data = response, message = "the survey was created successfully" }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Unauthorized(new { data = new { }, message = "Error create survey", isValid = false });
        }

        [Authorize]
        [HttpPut("")]
        public IActionResult Update(UpdateSurveyPayload payload)
        {
            try
            {
                var response = _surveyService.UpdateSurvey(payload);
                if (response != null) { return Ok(new { data = response, message = "the survey was updated successfully" }); }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Unauthorized(new { data = new { }, message = "Error update survey", isValid = false });
        }

        [Authorize]
        [HttpDelete("")]
        public IActionResult Delete(DeleteSurveyPayload payload)
        {
            try
            {
                var response = _surveyService.DeleteSurvey(payload);
                if (response) { return Ok(new { data = new { }, message = "the survey was deleted successfully" }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Unauthorized(new { data = new { }, message = "Error delete survey", isValid = false });
        }

        
        [HttpGet("{token}")]
        public IActionResult GetSurveyByToken(string token)
        {
            try
            {
                var response = _surveyService.GetSurveyByToken(token);
                if (response != null)
                {
                    return Ok(new { data = response, message = ""});
                }
                return BadRequest(new { message = "Not found token"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }
        }

        [HttpPost("user")]
        public IActionResult SurveyUser(SurveyUserPayload payload)
        {
            try
            {
                var response = _surveyService.SaveAnswerSurvey(payload);
                if (response != null)
                {
                    return Ok(new { data = response, message = "the survey user was inserted successfully" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return BadRequest(new { message = "Error save answers by user" });
        }
    }
}
