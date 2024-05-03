using Gas.Application;
using Gas.Utils;
using Gas.Utils.Settings;
using Gas.WorkerService;


IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        // Configure the Windows Service Name.
        options.ServiceName = "GMSService";
    })
    .ConfigureServices((hostContext, services) =>
    {
        var _configuration = hostContext.Configuration;
        var _contentRoot = hostContext.HostingEnvironment.ContentRootPath;
        services.ConfigureApplication();
        services.ConfigureUtils();
        services.AddWorkerServiceSettings(_configuration, _contentRoot);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
