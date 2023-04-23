using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using QB3API.Model.Security;
using QB3API.Model;

namespace QB3API.Helper
    {
        public static class JwtHelpers
        {
            public static IEnumerable<Claim> GetClaims(this User  user)
            {
                IEnumerable<Claim> claims = new Claim[] {
                    new Claim(ClaimTypes.Name, user.FirstName) 
            };
                return claims;
            }
          
            public static UserTokens GenTokenkey(User model, JwtSettings jwtSettings)
            {
            try
            {
                var UserToken = new UserTokens();
                if (model == null) throw new ArgumentException(nameof(model));
                // Get secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey); 
                DateTime expireTime = DateTime.UtcNow.AddDays(1);
                DateTime expireTimeMin = DateTime.UtcNow.AddMinutes(20);
                
                UserToken.ValidTill = expireTime;
                
                UserToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                    claims: GetClaims(model),//TODO : Add claimes. 
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTimeMin).DateTime,  
                    
                    signingCredentials: new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256)));

                 
                UserToken.RefreshToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(  
                    expires: new DateTimeOffset(expireTime).DateTime, 
                    signingCredentials: new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256)));
                return UserToken;
            }
            catch (Exception)
            {
                throw;
            }
            }
        }
    }
 
