using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TuChance.Dtos;

namespace TuChance.Payloads
{
    public class CreateSurveyPayload
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}
