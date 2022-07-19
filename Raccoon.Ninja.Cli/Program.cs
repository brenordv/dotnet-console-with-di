using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using Raccoon.Ninja.Cli;
using Raccoon.Ninja.Console.App.With.Di.Core.Constants;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;

Console.WriteLine("Hello, World!");
Disclaimer();

using var host = Bootstrap.Build(args, HttpConstants.HttpClientName);
var scope = host.Services.CreateScope();
var wizardRepository = scope.ServiceProvider.GetRequiredService<IWizardRepository>();
var genericHouseRepository = scope.ServiceProvider.GetRequiredService<IGenericHouseRepository>();
var houseRepository = scope.ServiceProvider.GetRequiredService<IHouseRepository>();

await ListHouses(houseRepository);
await ListGenericHouses(genericHouseRepository);
await ListWizards(wizardRepository);
await ListWizardById(wizardRepository);


//List all Houses.
static async Task ListHouses(IHouseRepository genericHouseRepository)
{
    var response = await genericHouseRepository.GetAsync();
    if (!response.Ok)
    {
        Console.WriteLine("Oh no! Could not list houses.");
        return;
    }
    
    foreach (var house in response.Value)
    {
        Console.WriteLine(house);
    }
}

//List all Houses using generic (Dictionary instead of Record) repository.
static async Task ListGenericHouses(IGenericHouseRepository genericHouseRepository)
{
    var response = await genericHouseRepository.GetAsync();
    if (!response.Ok)
    {
        Console.WriteLine("Oh no! Could not list generic houses.");
        return;
    }
    
    foreach (var genericHouse in response.Value)
    {
        Console.WriteLine("--------------------------------------------------");
        foreach (var (key, value) in genericHouse)
        {
            if (value is IList)
            {
                Console.WriteLine($"{key}:");
                foreach (var v in (IEnumerable)value)
                {
                    Console.WriteLine($"-- {v}");
                }
            }
            Console.WriteLine($"{key}: {value}");
        }
    }
}

//List a wizard by Id.
static async Task ListWizardById(IWizardRepository wizardFetcher)
{
    var response = await wizardFetcher.ListWizardIds();
    if (!response.Ok)
    {
        Console.WriteLine("Oh no! Could not get/list ids of the Wizards.");
        return;
    }

    var lastId = response.Value.Last();
    var wizard = await wizardFetcher.GetAsync(lastId);
    if (!wizard.Ok)
    {
        Console.WriteLine($"Oh no! No wizard found with Id '{lastId}'.");
        return;
    }
    
    Console.WriteLine($"Wizard with Id: {lastId}");
    Console.WriteLine(wizard.Value);
}

//List all wizards.
static async Task ListWizards(IWizardRepository wizardFetcher)
{
    Console.WriteLine("Listing Wizards...");
    var wizards = await wizardFetcher.GetAsync();
    if (!wizards.Ok)
    {
        Console.WriteLine("Oh no! Could not get the list of Wizards.");
        return;
    }
    
    foreach (var wizard in wizards.Value)
        Console.WriteLine(wizard);
}

static void Disclaimer()
{
    Console.WriteLine(@"
--------------------------------------------------------------------------------
Disclaimer: Although I created this application, the API I'm using is not mine. 
The API was made by MossPiglets and is located here: 
https://github.com/MossPiglets/WizardWorldAPI
--------------------------------------------------------------------------------
");
}

Console.WriteLine("Good bye!");
