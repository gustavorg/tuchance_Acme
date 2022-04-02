using System;
using System.Collections.Generic;
using TuChance.Payloads;

namespace TuChance.Dtos
{
    public class GetSurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public List<SurveyUserDto> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
