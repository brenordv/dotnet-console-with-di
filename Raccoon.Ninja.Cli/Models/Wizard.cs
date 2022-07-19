namespace Raccoon.Ninja.Cli.Models;

public record Wizard(string Id, string FirstName, string LastName, IList<Elixir> Elixirs);