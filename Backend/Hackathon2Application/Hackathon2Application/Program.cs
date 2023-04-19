using Hackathon2.Core.Interfaces.Repositories;
using Hackathon2.Core.Settings;
using Hackathon2.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SonaeMC.ECommerce.LegacyOMS.OrdersWorker.Worker;

public class Program
{
    public const string hackathonRepository = "HackathonRepository";

    public static void Main(string[] args)
    {
        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: false, reloadOnChange: true);



        var test = configurationBuilder.Build();

        CreateHostBuilder(args, configurationBuilder.Build()).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>

        Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddConfiguration(configuration);
        })
        .ConfigureServices((hostContext, services) =>
        {
            services.Configure<RepositorySettings>(configuration.GetSection(hackathonRepository));

            services.AddSingleton<IHackathonRepository, HackathonRepository>();
            services.AddLogging();
        });

}
