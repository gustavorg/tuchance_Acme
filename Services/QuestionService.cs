using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TuChance.Entities;
using TuChance.Helpers;
using TuChance.Data;
using TuChance.Interfaces;
using TuChance.Library;
using TuChance.Payloads;
using TuChance.Dtos;
using System.Collections.Generic;

namespace TuChance.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuestionData _questionData;

        public QuestionService(IOptions<AppSettings> appSettings)
        {
            _questionData = new QuestionData(appSettings);
        }

        public List<QuestionTypeDto> GetQuestionTypes()
        {
            return _questionData.GetQuestionTypes();
        }

    }
}
