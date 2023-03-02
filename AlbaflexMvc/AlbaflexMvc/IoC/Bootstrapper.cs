using AlbaflexMvc.Data;
using AlbaflexMvc.Data.Interfaces;
using AlbaflexMvc.Data.Repositories;
using AlbaflexMvc.Database;
using AlbaflexMvc.Services;
using AlbaflexMvc.Services.Interfaces;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;

namespace AlbaflexMvc.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, AlbaflexDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
            .AddPostgres()
            .WithGlobalConnectionString(DbInfoProvider.GetPostgresConnectionString())
            .ScanIn(typeof(DbInfoProvider).Assembly).For.Migrations());

            return services;
        }

    }
}
