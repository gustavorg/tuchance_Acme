using TuChance.Dtos;
using TuChance.Entities;
using TuChance.Payloads;

namespace TuChance.Interfaces
{
   public interface IAuthenticateService
    {
        AuthenticateDto Authenticate(GetAuthenticatePayload payload);
        UserDto GetSeed(int idUser,string token);
    }
}
