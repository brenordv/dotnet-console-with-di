using Raccoon.Ninja.Console.App.With.Di.Core.Extensions;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;
using Raccoon.Ninja.Console.App.With.Di.Core.Models;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

public class WizardRepository: BaseMagicalRepository<Wizard>, IWizardRepository
{
    public WizardRepository(IHttpClientFactory httpClientFactory) 
        : base(httpClientFactory, "wizards")
    { }
    
    public async Task<IMaybe<IList<string>>> ListWizardIds()
    {
        var httpResponse = await Fetch();
        var wizards = await httpResponse.ToModelList<Wizard>(); 
        return wizards.Bind(ws => ws.Select(wizard => wizard.Id).ToList());
    }
}