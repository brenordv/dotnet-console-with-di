using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Raccoon.Ninja.Console.App.With.Di.Core.Constants;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;
using Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

namespace Raccoon.Ninja.Cli;

public static class Bootstrap
{
    public static IHost Build(string[] args, string httpClientName)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                {
                    services.AddHttpClient(httpClientName, client =>
                    {
                        client.BaseAddress = new Uri("https://wizard-world-api.herokuapp.com/");
                        
                        //Using basic auth.
                        const string authString = $"{HttpConstants.FakeUsername}:{HttpConstants.FakePassword}";
                        var b64AuthString = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authString));
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Basic", b64AuthString);
                        
                        //Alternative way, using Bearer token
                        //client.DefaultRequestHeaders.Add("Authentication", HttpConstants.FakeAuthenticationToken);
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