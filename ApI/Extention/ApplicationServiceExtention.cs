using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApI.Data;
using ApI.interfaces;
using ApI.Services;
using Microsoft.EntityFrameworkCore;

namespace ApI.Extention
{
    public static class ApplicationServiceExtention
    {
        
        
        
         public static  IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration config )
         {
            services.AddScoped<ITokenService,TokenService>();
           services.AddDbContext<DataContext>
            (a => a.UseSqlServer(config.GetConnectionString("DefouitConection")));

             return services; 
         }

    }
}