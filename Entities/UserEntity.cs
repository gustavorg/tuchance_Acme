using System.Text.Json.Serialization;

namespace TuChance.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}