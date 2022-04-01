
namespace TuChance.Dtos
{
    public class AuthenticateDto
    {
        public AuthenticateDto(string role, string token)
        {
            Role = role;
            Token = token;
        }

        public string Role { get; set; }
        public string Token { get; set; }
    }
}
