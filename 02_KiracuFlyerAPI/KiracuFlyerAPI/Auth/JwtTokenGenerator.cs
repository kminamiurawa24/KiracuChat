using KiracuFlyerAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KiracuFlyerAPI.Auth
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            // ヘッダー
            var header = new JwtHeader(
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(File.ReadAllText(_configuration["Jwt:KeyFilePath"]))),
                    SecurityAlgorithms.HmacSha256));

            // ペイロード
            var payload = new JwtPayload(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.LoginId)
                },
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(7));

            // トークン
            var token = new JwtSecurityToken(header, payload);

            // トークン文字列を生成
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}