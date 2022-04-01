using System.Collections.Generic;
using TuChance.Dtos;
using TuChance.Data;
using TuChance.Interfaces;
using TuChance.Helpers;
using Microsoft.Extensions.Options;
using TuChance.Payloads;

namespace TuChance.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly AppSettings _appSettings;
        private readonly SurveyData _surveyData;

        public SurveyService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _surveyData = new SurveyData(appSettings);
        }

        public List<SurveyDto> GetAll()
        {
            return _surveyData.All();
        }

        public SurveyDto CreateSurvey(CreateSurveyPayload payload)
        {
            return _surveyData.CreateSurvey(payload);
        }

        public SurveyDto UpdateSurvey(UpdateSurveyPayload payload)
        {
            return _surveyData.UpdateSurvey(payload);
        }

        public bool DeleteSurvey(DeleteSurveyPayload payload)
        {
            return _surveyData.DeleteSurvey(payload);
        }
    }

    
}
