using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;
using Raccoon.Ninja.Console.App.With.Di.Core.Models;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;

public interface IWizardRepository: IBaseMagicalRepository<Wizard>
{
    Task<IMaybe<IList<string>>> ListWizardIds();
}