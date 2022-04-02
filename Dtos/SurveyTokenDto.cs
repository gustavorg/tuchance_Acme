using System.Collections.Generic;

namespace TuChance.Dtos
{
    public class SurveyTokenDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
