using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class CreateSurveyPayload
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<CreateQuestionPayload> Questions { get; set; }
    }
}
