using System;
using System.Collections.Generic;
using TuChance.Entities;
using TuChance.Payloads;

namespace TuChance.Interfaces
{
    public interface ISurveyService
    {
        List<SurveyDto> GetAll();
        SurveyDto CreateSurvey(CreateSurveyPayload payload);
        SurveyDto UpdateSurvey(UpdateSurveyPayload payload);
        bool DeleteSurvey(DeleteSurveyPayload payload);
    }
}
