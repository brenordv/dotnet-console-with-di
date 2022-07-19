namespace Raccoon.Ninja.Console.App.With.Di.Core.Extensions;

public static class StringExtensions
{
    public static bool IsValidGuid(this string text)
    {
        return !string.IsNullOrWhiteSpace(text) && Guid.TryParse(text, out _);
    }
}