using TuChance.Dtos;
using TuChance.Entities;
using TuChance.Payloads;

namespace TuChance.Interfaces
{
   public interface IAuthenticateService
    {
        AuthenticateDto Authenticate(GetAuthenticatePayload model);
        UserDto GetSeed(string token);
    }
}
