﻿using Microsoft.IdentityModel.Tokens;
using Practice_Identity_and_Data_Protection.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Practice_Identity_and_Data_Protection.Jwt
{
    public static class JwtHelper
    {
        public static string GenerateJwt(JwtDto JwtInfo)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecretKey));

            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id",JwtInfo.Id.ToString()),
                new Claim("Email",JwtInfo.Email),
                new Claim("UserType",JwtInfo.UserType.ToString()),

                new Claim(ClaimTypes.Role, JwtInfo.UserType.ToString())
            };

            var expireTime = DateTime.Now.AddMinutes(JwtInfo.ExpireMinutes);

            var tokenDescriptor = new JwtSecurityToken(JwtInfo.Issuer, JwtInfo.Audience, claims, null, expireTime, credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return token;
        }
    }
}
