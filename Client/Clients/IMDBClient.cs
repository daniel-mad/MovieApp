

using Microsoft.Extensions.Configuration;

namespace Client.Clients;

public class IMDBClient : IIMDBClient
{
    public IMDBClient(HttpClient client, IConfiguration configuration)
    {
        Key = configuration["IMDB-API:Key"];
        client.BaseAddress = new Uri(configuration["IMDB-API:Url"]);
        Client = client;
    }

    public HttpClient Client { get; }
    public string Key { get; }
}
