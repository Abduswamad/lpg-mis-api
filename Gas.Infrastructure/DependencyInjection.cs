using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Gas.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlite");
        }
    }
}
