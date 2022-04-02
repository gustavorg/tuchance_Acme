using System;
using System.Collections.Generic;
using TuChance.Payloads;

namespace TuChance.Dtos
{
    public class SurveyUserDto
    {
        public int IdSurvey { get; set; }
        public int IdUser { get; set; }
        public List<AnswerPayload> Answers { get; set; }
    }
}
