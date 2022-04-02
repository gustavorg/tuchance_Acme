using System;
using System.Collections.Generic;
using TuChance.Dtos;
using TuChance.Payloads;

namespace TuChance.Interfaces
{
    public interface ISurveyService
    {
        List<GetSurveyDto> GetAll();
        SurveyDto CreateSurvey(CreateSurveyPayload payload);
        SurveyDto UpdateSurvey(UpdateSurveyPayload payload);
        bool DeleteSurvey(DeleteSurveyPayload payload);
        SurveyTokenDto GetSurveyByToken(string token);
        SurveyUserDto SaveAnswerSurvey(SurveyUserPayload payload);
    }
}
