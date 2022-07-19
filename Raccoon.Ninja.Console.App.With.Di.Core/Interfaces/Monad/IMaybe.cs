namespace Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;

public interface IMaybe<out T>
{
    T Value { get; }
    bool Ok { get; }
    bool IsNull { get; }
    
    IMaybe<TOut> Bind<TOut>(Func<T, TOut> func);
    
}