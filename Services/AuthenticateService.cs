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
using TuChance.Dtos;
using TuChance.Payloads;

namespace TuChance.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UtilitiesExtensions _utilities;
        private readonly AuthenticateData _authenticateData;
        private readonly AppSettings _appSettings;

        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _authenticateData = new AuthenticateData(appSettings);
            _utilities = new UtilitiesExtensions(appSettings);
        }

        public AuthenticateDto Authenticate(GetAuthenticatePayload payload)
        {
            var user = _authenticateData.GetByEmail(payload);
            if (user != null)
            {
                if (_utilities.DecryptString(user.Password) == payload.Password)
                {
                    AuthenticateDto response = new(user.Role, GenerateJwtToken(user.Id));
                    return response;
                }
            }
            return null;
        }

        public UserDto GetSeed(string token)
        {
            return _authenticateData.GetSeed(token);
        }

        private string GenerateJwtToken(int idUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", idUser.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string _token = tokenHandler.WriteToken(token);
            _authenticateData.SaveToken(idUser, _token);
            return _token;
        }

    }
}
