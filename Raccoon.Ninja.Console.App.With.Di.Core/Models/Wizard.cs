namespace Raccoon.Ninja.Console.App.With.Di.Core.Models;

public record Wizard(string Id, string FirstName, string LastName, IList<Elixir> Elixirs);