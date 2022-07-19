using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;
using Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

namespace Raccoon.Ninja.Cli;

public static class Bootstrap
{
    public static IHost Build(string[] args, string httpClientName, string bearerToken)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                {
                    services.AddHttpClient(httpClientName, client =>
                    {
                        client.BaseAddress = new Uri("https://wizard-world-api.herokuapp.com/");
                        client.DefaultRequestHeaders.Add("Authentication", bearerToken);
                        client.DefaultRequestHeaders.Add("User-Agent", "ChallengeScript");
                    }).AddTransientHttpErrorPolicy(builder =>
                        builder.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(250)
                        ));
                    services
                        .AddScoped<IGenericHouseRepository, GenericHouseRepository>()
                        .AddScoped<IHouseRepository, HouseRepository>()
                        .AddScoped<IWizardRepository, WizardRepository>()
                        .AddScoped<IElixirRepository, ElixirRepository>();
                }).Build();
    }
}