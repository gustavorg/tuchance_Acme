using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class SurveyUserPayload
    {
        [Required]
        public int IdSurvey { get; set; }

        [Required]
        public List<AnswerPayload> Answers { get; set; }
    }
}
