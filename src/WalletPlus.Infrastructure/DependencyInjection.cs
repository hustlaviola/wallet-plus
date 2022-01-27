using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Infrastructure.Persistence;
using WalletPlus.Infrastructure.Persistence.Repositories;

namespace WalletPlus.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(builder => builder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("WalletPlus.API"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}