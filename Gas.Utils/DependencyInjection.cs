using Microsoft.Extensions.DependencyInjection;

namespace Gas.Utils;

public static class DependencyInjection
{
    public static void ConfigureUtils(this IServiceCollection services)
    {
        services.AddTransient(typeof(Result<>));      
    }
}