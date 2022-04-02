using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TuChance.Entities;
using TuChance.Helpers;
using TuChance.Data;
using TuChance.Interfaces;
using TuChance.Library;
using TuChance.Payloads;
using TuChance.Dtos;

namespace TuChance.Services
{
    public class UserService : IUserService
    {
        private readonly UtilitiesExtensions _utilities;
        private readonly UserData _userData;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _userData = new UserData(appSettings);
            _utilities = new UtilitiesExtensions(appSettings);
        }

        public UserDto CreateUser(CreateUserPayload payload)
        {
            payload.Password = _utilities.EncryptString(payload.Password);
            var res = _userData.CreateUser(payload);
            if (res != null)
            {
                return res;
            }
            return null;
        }

        public int CreateClient()
        {
            return _userData.CreateClient();
        }

    }
}
