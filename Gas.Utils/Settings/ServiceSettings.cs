using Gas.Domain.ModelSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace Gas.Utils.Settings
{
    public static class ServiceSettings
    {
        private static SettingsModel _SettingsModel = new();
        public static SettingsModel GetWorkerServiceSettings() => _SettingsModel;
        public static void AddWorkerServiceSettings(this IServiceCollection services, IConfiguration configuration, string contentRootPath = "")
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(contentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddConfigServer()
            .Build();
            configuration.Bind(_SettingsModel);
            _SettingsModel.ContentRootPath = contentRootPath;
            //_SettingsModel.DBConnection.QMSDB = "";

        }

    }
}
