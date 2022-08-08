using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApI.Data;
using ApI.Extention;
using ApI.interfaces;
using ApI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;



namespace API
{
    public class Startup

    {

        private readonly IConfiguration  config;
        public Startup(IConfiguration _config)
        {
            config = _config;
        }

      
          public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        //     services.AddScoped<ITokenService,TokenService>();
        //     services.AddDbContext<DataContext>
        //    (a => a.UseSqlServer(config.GetConnectionString("DefouitConection")));

             services.AddApplicationServices(config);  

            services.AddControllers();
            services.AddCors();



            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(option =>
            // {
            
            // option.TokenValidationParameters= new  TokenValidationParameters
            // {
            //     ValidateIssuerSigningKey= true,
            //     IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["tokenKey"])),
            //     ValidateIssuer = false,
            //     ValidateAudience =false,
            // };
            
            // });


            services.AddIdentityservices(config);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
