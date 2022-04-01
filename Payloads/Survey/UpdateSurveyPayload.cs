using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class UpdateSurveyPayload
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<CreateQuestionPayload> Questions { get; set; }
    }
}
