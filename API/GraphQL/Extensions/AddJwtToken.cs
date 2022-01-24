using BLL.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GraphQL.Extensions
{
    public static class AddJwtToken
    {
		public static void AddJwtTokenExtension(this IServiceCollection services, TokenSettings tokenSettings)
		{
            // Map repositories
            var signingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(tokenSettings.Key ?? ""));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidIssuer = tokenSettings.Issuer,
                            ValidAudience = tokenSettings.Audience,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = signingKey, 
                        };
                });
        }
	}
}
