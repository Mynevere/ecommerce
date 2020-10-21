using System;
using System.IO;
using AutoMapper;
using Infrastructure.Data.Context;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using skinet.Extenstions;
using skinet.Helpers;
using skinet.Middleware;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers().AddNewtonsoftJson();

            //Skinet database configuration
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            Action<DbContextOptionsBuilder> p = x =>
                   x.UseSqlServer(connectionString);
            services.AddDbContext<StoreContext>(p);

            services.AddDbContext<AppIdentityDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            //SkinetBasket database configuration
            string connectionStringBasket = Configuration.GetConnectionString("BasketDb");
            Action<DbContextOptionsBuilder> z = x => 
            x.UseSqlServer(connectionStringBasket);
            services.AddDbContext<BasketContext>(z);


            services.AddApplicationServices();
            services.AddIdentityServices(Configuration);
            services.AddSwaggerDocumentation();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"Content")
                ), RequestPath="/content"
            });


            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback"); 
            });
        }
    }
}