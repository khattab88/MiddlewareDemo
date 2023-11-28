using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace WebApp.Middlewares
{
    public class AppCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public AppCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Culture Middleware - Start");

            var cultureString = context.Request.Query["culture"];

            if(!string.IsNullOrWhiteSpace(cultureString)) 
            {
                var culture = new CultureInfo(cultureString);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

                await context.Response.WriteAsync($"culture middleware: {culture.Name} \n");
            }

            await _next(context);

            Console.WriteLine("Culture Middleware - End");
        }
    }
}
