using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenGenarator
    {
        public static TokenResponseViewModel TokenGenerator(GetCheckoutAppUserViewModel model)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

            if (!string.IsNullOrWhiteSpace(model.Username))
                claims.Add(new Claim("Username", model.Username));

            if (!string.IsNullOrWhiteSpace(model.Email))
                claims.Add(new Claim(ClaimTypes.Email, model.Email));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenDefault.ValidUssuare, audience: JwtTokenDefault.ValidAudiance, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();


            return new TokenResponseViewModel(jwtSecurityTokenHandler.WriteToken(jwtSecurityToken), expireDate);


        }
    }
}
