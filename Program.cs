using LibraryMemberFunction;
using LibraryMemberFunction.Application;
using LibraryMemberFunction.Application.Services;
using LibraryMemberFunction.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) => {

        var configuration = context.Configuration;

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddScoped<IMongoDbExecuter, MongoDbExecuter>();
        services.AddScoped<ILibraryMemberService, LibraryMemberService>();

        services.AddDatabaseSettings(configuration);
    })
    .Build();

await host.RunAsync();