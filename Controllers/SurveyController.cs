using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TuChance.Interfaces;
using TuChance.Entities;
using System;
using TuChance.Models;
using TuChance.Payloads;

namespace TuChance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService estateService)
        {
            _surveyService = estateService;
        }

        [Authorize]
        [HttpGet("")]
        public IActionResult GetAll()
        {
            List<SurveyDto> estates;
            try
            {
                estates = _surveyService.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Ok(new { data = estates, message = "", isValid = true });
        }

        [HttpPost("")]
        public IActionResult CreateSurvey(CreateSurveyPayload payload)
        {
            try
            {
                var response = _surveyService.CreateSurvey(payload);
                if (response != null) { return Ok(new { data = response, message = "the survey was created successfully", isValid = true }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Unauthorized(new { data = new { }, message = "Error create survey", isValid = false });
        }

        [HttpPut("")]
        public IActionResult Update(UpdateSurveyPayload payload)
        {
            try
            {
                var response = _surveyService.UpdateSurvey(payload);
                if (response != null) { return Ok(new { data = response, message = "the survey was updated successfully", isValid = true }); }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Unauthorized(new { data = new { }, message = "Error update survey", isValid = false });
        }

        [HttpDelete("")]

        public IActionResult Delete(DeleteSurveyPayload payload)
        {
            try
            {
                var response = _surveyService.DeleteSurvey(payload);
                if (response) { return Ok(new { data = new { }, message = "the survey was deleted successfully", isValid = true }); }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, isValid = false });
            }

            return Unauthorized(new { data = new { }, message = "Error delete survey", isValid = false });
        }
    }
}
