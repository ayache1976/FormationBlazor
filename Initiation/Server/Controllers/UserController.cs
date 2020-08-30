using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Initiation.Server.Data;
using Initiation.Server.Models;
using Initiation.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NSwag.Annotations;

namespace Initiation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("User", Description = "User Controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _configuration;
        private static TextInfo tInfo = CultureInfo.CurrentCulture.TextInfo;
        public UserController(IUserRepository repos, IConfiguration configuration)
        {
            _repo = repos;
            _configuration = configuration;
        }

        [HttpPost("register")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "L'utilisateur << Nom >> existe déjà")]
        public async Task<IActionResult> Register(DtoUser dto)
        {
            dto.UserName = dto.UserName.ToLower();
            if (await _repo.UserExits(dto.UserName))
            {
                return BadRequest($"L'utilisateur <<{tInfo.ToTitleCase(dto.UserName)}>> existe déjà");
            }

            var userToCreate = new User { UserName = dto.UserName };
            await _repo.Register(userToCreate, dto.Password);
            return Ok();
        }
        [HttpPost("login")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(DtoUserForLogin), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(string), Description = "L'utilisateur << Nom >> n'est pas à se connecter")]
        public async Task<IActionResult> Login(DtoUser dto)
        {
            dto.UserName = dto.UserName.ToLower();

            var userFromRepos = await _repo.Login(dto.UserName, dto.Password);
            if (userFromRepos == null)
                return Unauthorized("Pas autorisé à se connecter");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepos.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepos.UserName)
            };
            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingsToken));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginDto = new DtoUserForLogin
            {
                UserName = dto.UserName,
                Token = tokenHandler.WriteToken(token)
            };

            return Ok(loginDto);
        }


        [HttpPost("available")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Ok")]
        public async Task<IActionResult> Available(DtoUserForLogin dto)
        {
            dto.UserName = dto.UserName.ToLower();
            var swAvailable = await _repo.UserExits(dto.UserName);
            return Ok(!swAvailable);
        }

    }
}
