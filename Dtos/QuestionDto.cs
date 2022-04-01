using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace TuChance.Entities
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
