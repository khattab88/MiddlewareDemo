using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;
using WebApp.Middlewares;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // register middleware to DI
            services.AddTransient<LoggingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppCulture();

            app.UseMiddleware<LoggingMiddleware>();

            // inline middleware
            app.Use(async (context, next) => 
            {
                Console.WriteLine("inline middleware started");
                await context.Response.WriteAsync("this is inline middleware \n");
                await next();
                Console.WriteLine("inline middleware ended");
            });

            // branching middleware based on path
            app.Map("/health", HealthCheckHandler);

            // terminal middleware
            app.Run(async context => await context.Response.WriteAsync("welcome to terminal middleware"));
        }

        private void HealthCheckHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Console.WriteLine("health check middleware");
                await context.Response.WriteAsync("health check middleware");
            });
        }
    }
}
