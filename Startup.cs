using Api_fvg.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api_fvg
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var userClaims = await UserManager.GetClaimsAsync(user.Id);
            //Claim companyClaim = userClaims.Claims.Where(c => c.Type = "CompanyClaim").FirstOrDefault();

            //string con = "Data Source=Melik-pc\\SQL14;Persist Security Info=False;Initial Catalog=FvgDB;User ID=sa;Password=Sqlserver2018";
            string con = "Data Source=WIN-M5M1I1A1D8C\\SQL14;Persist Security Info=False;Initial Catalog=FvgDB;User ID=sa;Password=Sqlserver2021";

            // устанавливаем контекст данных
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(con));
            services.AddDbContext<AccsContext>(options => options.UseSqlServer(con));
            services.AddDbContext<ClientsContext>(options => options.UseSqlServer(con));

            services.AddControllers(); // используем контроллеры без представлений
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
