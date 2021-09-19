using Grocery.InfraInstructure.Data;
using Grocery.InfraInstructure.Data.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.Infrastructure.Data.DataRegistration
{
    public static class DataRegsitration
    {
        public static IServiceCollection AddDataRegistration(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DbContext, GroceryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sql_connection"));
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            return services;
        }
    }
}
