using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;
using WebApp.Middlewares;

namespace WebApp.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAppCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppCultureMiddleware>();
        }
    }
}
