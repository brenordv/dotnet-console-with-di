using Newtonsoft.Json;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Models;

public record House(
    string Id,
    string Name,
    [JsonProperty("houseColours")] string HouseColors,
    string Founder,
    string Animal,
    string Element,
    string Ghost,
    string CommonRoom,
    IList<HouseHead> Heads,
    IList<HouseTrait> Traits
);