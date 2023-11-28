using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApp.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("LoggingMiddleware  started");
            await context.Response.WriteAsync("this is logging middleware \n");
            await next(context);
            Console.WriteLine("LoggingMiddleware  ended");
        }
    }
}
