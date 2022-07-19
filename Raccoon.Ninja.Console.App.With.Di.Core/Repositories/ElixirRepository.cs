using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;
using Raccoon.Ninja.Console.App.With.Di.Core.Models;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

public class ElixirRepository: BaseMagicalRepository<Elixir>, IElixirRepository
{
    public ElixirRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory, "elixirs")
    {
    }
}