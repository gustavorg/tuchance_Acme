using System.Collections.Generic;
using TuChance.Dtos;
using TuChance.Data;
using TuChance.Interfaces;
using TuChance.Helpers;
using Microsoft.Extensions.Options;
using TuChance.Payloads;
using System;
using System.Linq;

namespace TuChance.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly AppSettings _appSettings;
        private readonly SurveyData _surveyData;
        private readonly UserData _userData;
        private readonly QuestionData _questionData;

        public SurveyService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _surveyData = new SurveyData(appSettings);
            _questionData = new QuestionData(appSettings);
            _userData = new UserData(appSettings);
        }

        public List<GetSurveyDto> GetAll()
        {
            return _surveyData.All();
        }

        public SurveyDto CreateSurvey(CreateSurveyPayload payload)
        {
            var token = GenerateToken();
            if (!ValidateListQuestion(payload.Questions))
            {
                return null;
            }
            return _surveyData.CreateSurvey(payload,token);
        }

        public SurveyDto UpdateSurvey(UpdateSurveyPayload payload)
        {
            if (!ValidateListQuestion(payload.Questions))
            {
                return null;
            }
            return _surveyData.UpdateSurvey(payload);
        }

        public bool DeleteSurvey(DeleteSurveyPayload payload)
        {
            return _surveyData.DeleteSurvey(payload);
        }

        public SurveyTokenDto GetSurveyByToken(string token)
        {
            return _surveyData.GetSurveyByToken(token);
        }

        public SurveyUserDto SaveAnswerSurvey(SurveyUserPayload payload)
        {
            if (!ValidateListAnswer(payload))
            {
                return null;
            }
            var idUser = _userData.CreateClient();

            return _surveyData.SaveAnswerSurvey(payload,idUser);
        }

        private bool ValidateListQuestion(List<QuestionDto> questions)
        {
            if (questions.Count > 0)
            {
                var listQuestionTypes = _questionData.GetQuestionTypes();
                foreach (QuestionDto question in questions)
                {
                    var type = listQuestionTypes.FirstOrDefault(x => x.Id.Equals(question.IdQuestionType));
                    if (type == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ValidateListAnswer(SurveyUserPayload payload)
        {
            var answers = payload.Answers;
            // exist survey
            var survey = _surveyData.Get(payload.IdSurvey);
            if(survey == null) { return false; }

            // validate existQuestion
            if (answers.Count > 0)
            {
                var questions = survey.Questions;
                foreach (AnswerPayload answer in answers)
                {
                    var idQuestion = questions.FirstOrDefault(x => x.Name.Equals(answer.Name));
                    if (idQuestion == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static string GenerateToken()
        {
            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultToken = new string(
               Enumerable.Repeat(allChar, 50)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            return resultToken.ToString();
        }
    }

    
}
