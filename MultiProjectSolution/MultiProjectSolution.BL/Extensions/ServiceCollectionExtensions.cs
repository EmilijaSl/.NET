using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiProjectSolution.BL.Extensions
{
    public static class ServiceCollectionExtensions //extensionam turi buti statine klase
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IBusinessLogic, BusinessLogic>();
            return services;
        }
    }
}
