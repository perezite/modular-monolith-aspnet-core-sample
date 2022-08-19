using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Catalog.Core.Interfaces;
using Module.Catalog.Core.Services;
using Module.Catalog.Infrastructure.Persistence;
using Module.People.Core.Interfaces;
using Module.People.Core.Services;
using Module.People.Infrastructure.Persistence;

namespace App.Dependencies
{
    public static class DependencyRegistration
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddModuleDbContext<ICatalogDbContext, CatalogDbContext>(config)
                .AddModuleDbContext<IPersonDbContext, PersonDbContext>(config)
                .AddScoped<IBrandService, BrandService>()
                .AddScoped<IPersonService, PersonService>();
        }

        public static IServiceCollection AddWebApiControllers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new AppControllerFeatureProvider());
                });

            return services;
        }

        private static IServiceCollection AddModuleDbContext<TDbContextInterface, TDbContext>(this IServiceCollection services, IConfiguration config) where TDbContext : DbContext, TDbContextInterface where TDbContextInterface : class
        {
            services
                .AddDbContext<TDbContext>(config)
                .AddScoped<TDbContextInterface>(provider => provider.GetService<TDbContext>());

            return services;
        }

        private static IServiceCollection AddDbContext<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
        {
            var connectionString = config.GetConnectionString("Default");
            services.AddMSSQL<T>(connectionString);
            return services;
        }

        private static IServiceCollection AddMSSQL<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddDbContext<T>(m => m.UseSqlServer(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();
            return services;
        }
    }
}
