
namespace TuChance.Entities
{
    public class AuthenticateDto
    {
        public string Role { get; set; }
        public string Token { get; set; }

        public AuthenticateDto(string _role, string _token)
        {
            Role = _role;
            Token = _token;
        }
    }
}
