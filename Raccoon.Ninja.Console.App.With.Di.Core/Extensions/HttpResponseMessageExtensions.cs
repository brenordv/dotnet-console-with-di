using Newtonsoft.Json;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;
using Raccoon.Ninja.Console.App.With.Di.Core.Monad;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Extensions;

public static class HttpResponseMessageExtensions
{
    private static async Task<string> GetBodyContent(this HttpResponseMessage response)
    {
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<IMaybe<T>> ToModel<T>(this HttpResponseMessage response)
    {
        var body = await response.GetBodyContent();
        return new Maybe<string>(body).Bind(JsonConvert.DeserializeObject<T>);
    }
    
    public static async Task<IMaybe<IList<T>>> ToModelList<T>(this HttpResponseMessage response)
    {
        var body = await response.GetBodyContent();
        return new Maybe<string>(body).Bind(JsonConvert.DeserializeObject<IList<T>>);
    } 
    
    public static async Task<IMaybe<IDictionary<string, object>>> ToGeneric(this HttpResponseMessage response)
    {
        var body = await response.GetBodyContent();
        return new Maybe<string>(body)
            .Bind(JsonConvert.DeserializeObject<Dictionary<string, object>>)
            .Bind(dict => dict.Sanitize());
    }
    
    public static async Task<IMaybe<IList<IDictionary<string, object>>>> ToGenericList(this HttpResponseMessage response)
    {
        var body = await response.GetBodyContent();
        return new Maybe<string>(body)
            .Bind(JsonConvert.DeserializeObject<IList<IDictionary<string, object>>>)
            .Bind(list => list.Select(dict => dict.Sanitize()).ToList());
    }
}