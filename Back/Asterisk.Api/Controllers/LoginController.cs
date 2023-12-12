using Asterisk.Domain.Commands.Authentications;
using Asterisk.Domain.Entities;
using Asterisk.Domain.Handlers.Authentications;
using Asterisk.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Asterisk.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LoginCommand command, [FromServices] LoginHandle handle)
        {
            var result = (GenericCommandResult)handle.Handler(command);

            if (result.SuccessFailure)
            {
                var token = GenerateJSONWebToken((User)result.Data);

                return new GenericCommandResult(true, "User successfully logged in!", new { token = token });
            }

            return new GenericCommandResult(false, result.Message, result.Data);
        }



        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Asterisk-authentication-key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Name),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(ClaimTypes.Role, userInfo.UserType.ToString()),
            new Claim("role", userInfo.UserType.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken(
                "asterisk",
                "asterisk",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
