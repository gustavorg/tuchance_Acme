using TuChance.Dtos;
using TuChance.Payloads;

namespace TuChance.Interfaces
{
   public interface IUserService
    {
        UserDto CreateUser(CreateUserPayload model);
    }
}
