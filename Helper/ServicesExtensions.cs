﻿ 
using QB3API.Model.Security;

namespace QB3API.Helper
{
    public static class ServicesExtensions
    {
        //public static void AddJWTToken(this IServiceCollection Services, ConfigurationManager Configuration)
        //{
        //    // Add Jwt Setings
        //    var bindJwtSettings = new JwtSettings();
        //    Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
        //   // Services.AddSingleton(bindJwtSettings);
        //    Services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(options =>
        //    {
        //        options.RequireHttpsMetadata = false;
        //        options.SaveToken = true;
        //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        //        {
        //            ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
        //            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
        //            ValidateIssuer = bindJwtSettings.ValidateIssuer,
        //            ValidIssuer = bindJwtSettings.ValidIssuer,
        //            ValidateAudience = bindJwtSettings.ValidateAudience,
        //            ValidAudience = bindJwtSettings.ValidAudience,
        //            RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
        //            ValidateLifetime = bindJwtSettings.RequireExpirationTime,
        //            ClockSkew = TimeSpan.FromDays(1),
        //        };
        //    }
            
        //    );
        //}
    }

}