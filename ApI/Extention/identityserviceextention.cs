using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ApI.Extention
{
    public static class Identityserviceextention


    {
         public static  IServiceCollection AddIdentityservices(this IServiceCollection services,IConfiguration config )
         {
             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
            
            option.TokenValidationParameters= new  TokenValidationParameters
            {
                ValidateIssuerSigningKey= true,
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["tokenKey"])),
                ValidateIssuer = false,
                ValidateAudience =false,
            };
            
            });

             return services; 
         }
    }
}