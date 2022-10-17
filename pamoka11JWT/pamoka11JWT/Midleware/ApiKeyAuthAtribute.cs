using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace pamoka11JWT.Midleware
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
       
        //atributas tai kaip dekoracija ant klases priemone pazymeti metodus ir klases tokiu budu galime pakeisti kaip mes ta klase ar metoda naudojam
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
