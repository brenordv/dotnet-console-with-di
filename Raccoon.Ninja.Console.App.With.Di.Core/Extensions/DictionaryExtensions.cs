using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;
using Raccoon.Ninja.Console.App.With.Di.Core.Models;
using Raccoon.Ninja.Console.App.With.Di.Core.Monad;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Extensions;

public static class DictionaryExtensions
{
    private static object SanitizeValue(object value)
    {
        if (value == null) return null;
        object val = null;

        switch (value)
        {
            case JObject jo:
                var dict = jo.ToObject<Dictionary<string, object>>();
                if (dict == null) break;
                
                foreach (var (key, o) in dict) 
                    dict[key] = SanitizeValue(o);
                
                val = dict;
                break;

            case JArray ja:
                val = ja.ToObject<List<object>>();
                break;

            case IDictionary<string, object> di:
                foreach (var (key, o) in di) 
                    di[key] = SanitizeValue(o);
                
                val = di;
                break;

            default:
                val = value;
                break;
        }

        return val;
    }
    
    public static IDictionary<string, object> Sanitize(this IDictionary<string, object> dict)
    {
        foreach (var (key, value) in dict)
            dict[key] = SanitizeValue(value);

        return dict;
    }
}