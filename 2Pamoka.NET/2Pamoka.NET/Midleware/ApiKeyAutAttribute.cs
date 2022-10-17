using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _2Pamoka.NET.Midleware
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiKeyAutAttribute :Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) ///sita dalis ir sitos dalies kontroleris sujungia su APIKeyAUthAttribute
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKeyFromHeader))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeyFromConfiguration = configuration.GetValue<string>("ApiKey");

            if (apiKeyFromHeader != apiKeyFromConfiguration)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            await next();
        }
    }
}
