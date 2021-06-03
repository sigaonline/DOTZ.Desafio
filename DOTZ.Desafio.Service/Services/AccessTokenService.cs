using DOTZ.Desafio.Model;
using DOTZ.Desafio.Model.Exceptions;
using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Model.Result;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Services;
using DOTZ.Desafio.Service.Interface.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly JwtTokenSettings jwtTokenSettings;
        private readonly IUserProvider userProvider;
        public AccessTokenService(IOptions<JwtTokenSettings> jwtTokenSettings, IUserProvider userProvider)
        {
            this.jwtTokenSettings = jwtTokenSettings.Value;
            this.userProvider = userProvider;
        }

        public async Task<UserResult> GenerateToken(LoginRequesty userRequest)
        {
            var checkUser = await userProvider.GetByAuthenticUserAsync(userRequest.UserName, userRequest.Password);
            if (checkUser?.Id == null)
                throw new BusinessException(ExceptionMessages.UserNotFound);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                      new Claim[]
                      {
                          new Claim(ClaimTypes.Name, userRequest.UserName),
                          new Claim(ClaimTypes.Role, ((UserRoles)int.Parse(checkUser.Role)).ToString()),
                      }
                     ),
                Expires = DateTime.UtcNow.AddHours(jwtTokenSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenSettings.Key)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserResult
            {
                Id = checkUser.Id,
                Role = ((UserRoles)int.Parse(checkUser.Role)).ToString(),
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
