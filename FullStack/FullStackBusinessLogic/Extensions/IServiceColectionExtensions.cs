using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FullStackBL.Extensions
{
    public static  class IServiceColectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddScoped<IUserAccountService, UserAccountsService>(); //+

            services.AddScoped<IJwtService, JwtService>(); //+


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //sita eilute pridedam ws 
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                });
            return services;

        }
    }

}
