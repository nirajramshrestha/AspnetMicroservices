using Identity.API.Configuration;
using Identity.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSetting appSetting;

        public AuthController(IOptions<AppSetting> options)
        {
            if (options != null)
            {
                this.appSetting = options.Value;
            }
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            if (user.UserName == this.appSetting.Jwt.TokenUserName && user.Password == this.appSetting.Jwt.TokenPassword)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSetting.Jwt.Key));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenExpirationSeconds = this.appSetting.Jwt.TokenExpirationSeconds > 10 ? (this.appSetting.Jwt.TokenExpirationSeconds - 10) : this.appSetting.Jwt.TokenExpirationSeconds;


                var tokeOptions = new JwtSecurityToken(
                    issuer: this.appSetting.Jwt.Issuer,
                    audience: this.appSetting.Jwt.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddSeconds(this.appSetting.Jwt.TokenExpirationSeconds),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, tokenExpirationSeconds = tokenExpirationSeconds });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
