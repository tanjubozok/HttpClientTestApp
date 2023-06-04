using HttpClientTest.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientTest.Service.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database ConnectionString

        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("LocalSqlServer"));
        });

        #endregion

    }
}
