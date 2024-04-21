using Gas.Domain.ModelSettings;
using Gas.Extensions;
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

            _SettingsModel.DBConnection.GasDB = Encryption.DecryptData(_SettingsModel.DBConnection.GasDB);
            _SettingsModel.Email.SenderEmail = Encryption.DecryptData(_SettingsModel.Email.SenderEmail);
            _SettingsModel.Email.SenderPassword = Encryption.DecryptData(_SettingsModel.Email.SenderPassword);
            _SettingsModel.Email.PortalURL = Encryption.DecryptData(_SettingsModel.Email.PortalURL);

            //_SettingsModel.DBConnection.QMSDB = "";

        }

    }
}
