using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;
using Raccoon.Ninja.Console.App.With.Di.Core.Models;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

public class HouseRepository: BaseMagicalRepository<House>, IHouseRepository
{
    public HouseRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory, "houses")
    {
    }
}