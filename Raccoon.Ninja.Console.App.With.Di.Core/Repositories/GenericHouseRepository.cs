using Raccoon.Ninja.Console.App.With.Di.Core.Extensions;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

public class GenericHouseRepository: BaseMagicalRepository<IDictionary<string, object>>, IGenericHouseRepository
{
    public GenericHouseRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory, "houses")
    {
    }

    public override async Task<IMaybe<IDictionary<string, object>>> GetAsync(string id)
    {
        if (!id.IsValidGuid())
            throw new ArgumentException("Id must be a valid Guid (uuid4).");
        
        var httpResponse = await Fetch(id);
        return await httpResponse.ToGeneric();
    }

    public override async Task<IMaybe<IList<IDictionary<string, object>>>> GetAsync()
    {
        var httpResponse = await Fetch();
        return await httpResponse.ToGenericList();
    }
}