using Raccoon.Ninja.Console.App.With.Di.Core.Constants;
using Raccoon.Ninja.Console.App.With.Di.Core.Extensions;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Monad;
using Raccoon.Ninja.Console.App.With.Di.Core.Interfaces.Repositories;

namespace Raccoon.Ninja.Console.App.With.Di.Core.Repositories;

public abstract class BaseMagicalRepository<T>: IBaseMagicalRepository<T>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseEndpoint;
    
    protected BaseMagicalRepository(IHttpClientFactory httpClientFactory, string baseEndpoint)
    {
        _httpClientFactory = httpClientFactory;
        _baseEndpoint = baseEndpoint;
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (string.IsNullOrWhiteSpace(_baseEndpoint))
            throw new AggregateException("BaseEndpoint cannot be null.");
        
        if (_httpClientFactory == null)
            throw new AggregateException("HttpFactory cannot be null.");
    }
    
    protected async Task<HttpResponseMessage> Fetch(string id = null)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpConstants.HttpClientName);
        var response = await httpClient.GetAsync(string.IsNullOrWhiteSpace(id)? _baseEndpoint : $"{_baseEndpoint}/{id}");
        response.EnsureSuccessStatusCode();
        return response;
    }
    
    public virtual async Task<IMaybe<T>> GetAsync(string id)
    {
        if (!id.IsValidGuid())
            throw new ArgumentException("Id must be a valid Guid (uuid4).");
        
        var httpResponse = await Fetch(id);
        return await httpResponse.ToModel<T>();
    }

    public virtual async Task<IMaybe<IList<T>>> GetAsync()
    {
        var httpResponse = await Fetch();
        return await httpResponse.ToModelList<T>();
    }
}