using MVCBaseProject.Models;
using MVCStrategyPattern.Models;
using MVCStrategyPattern.Repository;

namespace MVCStrategyPattern;

public static class ServiceRegistrationExtension
{
    public static void RegisterRepositories(IServiceCollection services)
    {
        services.AddHttpContextAccessor(); //http context accces for claims
        services.AddScoped<IProductRepository>(serviceProvider =>
        {
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var claim = httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == Settings.claimDatabaseType).FirstOrDefault();

            var context = serviceProvider.GetRequiredService<AppDbContext>();
            var config = serviceProvider.GetRequiredService<IConfiguration>();

            if (claim == null) return new SqlServerProductRepository(context);

            var databaseType = (EDatabaseType)int.Parse(claim.Value);

            return databaseType switch
            {
                EDatabaseType.SqlServer => new SqlServerProductRepository(context),
                EDatabaseType.MongoDb => new MongoDbProductRepository(config),
                _ => new SqlServerProductRepository(context)

            };

        });
    }
}
