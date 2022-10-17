using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDAL.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FullStackDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DbConnection")));  //+

            services.AddScoped<IDbRepository, DbRepository>(); //kur reikes idb repository konstruok db repository. Kai reikes servis. Visas priklausomybes apsirasom per konstruktoriuje ir jas priregistruojam program cs pries buildinant aplikacija. 
            return services;
        }

    }
}
