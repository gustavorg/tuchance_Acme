using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class CreateQuestionPayload
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsRequired { get; set; }

        [Required]
        public bool IdQuestionType { get; set; }
    }
}
