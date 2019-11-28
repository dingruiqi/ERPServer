using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ERPServer.Models;
using Microsoft.IdentityModel.Tokens;

namespace ERPServer.Bussiness.JWTHelper
{
    public class JWTHelper
    {
        public static JWTSetting Setting = new JWTSetting();

        public static string CreateJWTToken()
        {
            //对称秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Setting.SecretKey));
            //签名证书(秘钥，加密算法)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]{
                     //new Claim(ClaimTypes.Name,"ztb"),
                     //new Claim(ClaimTypes.Role,"admin"),
                     new Claim(ClaimTypes.NameIdentifier,"ERP后端服务验证"),
                 };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: Setting.Issuer,
                audience: Setting.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}