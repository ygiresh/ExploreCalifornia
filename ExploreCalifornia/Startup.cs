using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExploreCalifornia
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                DeveloperExceptions = _configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });

            services.AddTransient<FormattingService>();

            services.AddDbContext<BlogDataContext>(options =>
            {
                var connectionString = _configuration.GetConnectionString("BlogDataContext");
                options.UseSqlServer(connectionString);
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FeatureToggles features)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    if(context.Request.Path.Value.StartsWith("/hello"))
            //    {
            //        await context.Response.WriteAsync("Hello World! ASP.NET Core");
            //    }
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseExceptionHandler("/error.html");

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //if (_configuration["EnableDeveloperExceptions"] == "True")
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //if (_configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions"))
            //{
            //    app.UseDeveloperExceptionPage();
            //}


            if (features.DeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{Id:int?}"

                 );
            });

            app.UseFileServer();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.StartsWith("/invalid"))
                {
                    throw new Exception("error");
                }
                await next();
            });



        }
    }
}
