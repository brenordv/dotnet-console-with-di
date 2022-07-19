using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;

public interface IBaseMagicalRepository<T>
{
    Task<IMaybe<T>> GetAsync(string id);
    Task<IMaybe<IList<T>>> GetAsync();
}