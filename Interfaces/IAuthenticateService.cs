using TuChance.Entities;
using TuChance.Payloads;

namespace TuChance.Interfaces
{
   public interface IAuthenticateService
    {
        AuthenticateDto Authenticate(GetAuthenticatePayload model);
        UserEntity GetSeed(string token, string _ref);
    }
}
