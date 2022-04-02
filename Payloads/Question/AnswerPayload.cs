using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class AnswerPayload
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
