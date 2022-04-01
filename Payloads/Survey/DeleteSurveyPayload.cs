using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class DeleteSurveyPayload
    {
        [Required]
        public string Id { get; set; }
    }
}
