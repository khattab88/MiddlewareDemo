using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => 
            {
                Console.WriteLine("middleware 1 started");
                await context.Response.WriteAsync("this is middleware 1 \n");
                await next();
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("middleware 2 started");
                await context.Response.WriteAsync("this is middleware 2 \n");
                await next();
            });

            app.Run(async context => await context.Response.WriteAsync("welcome to terminal middleware"));
        }
    }
}
