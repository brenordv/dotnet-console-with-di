using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Monad;

/// <summary>
///     Simple implementation of a Monad-like processing.
/// </summary>
/// <typeparam name="T">Type of the value</typeparam>
public class Maybe<T> : IMaybe<T>
{
    /// <summary>
    ///     Readonly current value.
    /// </summary>
    public T Value { get; }

    /// <summary>
    ///     If the Value is not null.
    /// </summary>
    public bool Ok => Value != null;

    /// <summary>
    ///     If the Value is null.
    /// </summary>
    public bool IsNull => Value == null;

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="value">Value that will be used on this chain.</param>
    public Maybe(T value)
    {
        Value = value;
    }

    /// <summary>
    ///     Using the current value, will run the function passed as argument and return another Maybe object.
    /// </summary>
    /// <param name="func">To be executed using the current Value in this instance and will return a
    /// value of the same type.</param>
    /// <returns>New Maybe wrapper with the func result value.</returns>
    public IMaybe<TOut> Bind<TOut>(Func<T, TOut> func)
    {
        return new Maybe<TOut>(
            Value == null
                ? default
                : func(Value)
        );
    }
}