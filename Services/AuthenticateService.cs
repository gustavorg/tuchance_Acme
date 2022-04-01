using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TuChance.Entities;
using TuChance.Helpers;
using TuChance.Models;
using TuChance.Data;
using TuChance.Interfaces;
using TuChance.Library;

namespace TuChance.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        private readonly AuthenticateData _authenticateData;

        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _authenticateData = new AuthenticateData(appSettings);
        }

        public AuthenticateResponse Register(RegisterRequest model)
        {
            UtilitiesExtensions _utility = new();
            model.Password = _utility.EncryptString(model.Password);
            var res = _authenticateData.Register(model);
            if (res > 0)
            {
                AuthenticateRequest auth = new();
                auth._ref = model._ref;
                auth.Email = model.Email;
                var user = _authenticateData.GetByEmail(auth);
                if (user != null)
                {
                    AuthenticateResponse response = new(user.UserType, GenerateJwtToken(user.Id, model._ref));
                    return response;
                }
            }
            return null;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _authenticateData.GetByEmail(model);
            if (user.Id != 0)
            {
                UtilitiesExtensions _utility = new();
                if (_utility.DecryptString(user.Password) == model.Password)
                {
                    AuthenticateResponse response = new(user.UserType, GenerateJwtToken(user.Id, model._ref));
                    return response;
                }
            }
            return null;
        }
        public UserEntity GetByEmail(AuthenticateRequest model)
        {
            var user = _authenticateData.GetByEmail(model);
            Console.WriteLine(user);
            if (user.Id != 0)
            {
                return user;
            }
            return null;
        }

        public UserEntity GetSeed(string token, string _ref)
        {
            return _authenticateData.GetSeed(token, _ref);
        }

        public bool Password(string email)
        {
            try
            {
                AuthenticateRequest auth = new();
                auth.Email = email;
                auth._ref = "wi-estate";
                var user = GetByEmail(auth);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    var sendGridClient = new SendGridClient(_appSettings.SendgridKey);
                    var from = new EmailAddress("correoswinning@gmail.com", "Wi Estate");
                    var subject = "Nueva contraseña Wi Estate";
                    var to = new EmailAddress(email);
                    var plainContent = "";
                    var newPassword = CreatePassword();

                    var htmlContent = "<p>Estimado(a) " + user.Names + " " + user.LastName + ",</p>";
                    htmlContent += "<p>Su nueva contraseña es: <b>" + newPassword + "</b>. Puede cambiarla ingresando a la plataforma y eligiendo la opción \"Mi Perfil\".</p>";
                    htmlContent += "<p>Ahora puede ingresar nuevamente a la parte administrativa de su web</p>";
                    htmlContent += "<p>Gracias por ser parte de nuestra familia.</p>";
                    htmlContent += "<p>Equipo Wi Estate</p>";

                    var mailMessage = MailHelper.CreateSingleEmail(from, to, subject, plainContent, htmlContent);
                    sendGridClient.SendEmailAsync(mailMessage);
                    UtilitiesExtensions _utility = new();
                    string password = _utility.EncryptString(newPassword);
                    _authenticateData.UpdatePasword(user.Id, password);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
                return false;
            }
        
        
        
        
        }

        public string CreatePassword()
        {
            int length = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new();
            Random rnd = new();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private string GenerateJwtToken(int idUser, string _ref)
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
            _authenticateData.SaveToken(idUser, _ref, _token);
            return _token;
        }
    }
}
