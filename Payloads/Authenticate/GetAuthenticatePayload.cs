using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuChance.Payloads
{
    public class GetAuthenticatePayload
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
