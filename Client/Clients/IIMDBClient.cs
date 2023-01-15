namespace Client.Clients;

public interface IIMDBClient
{
    HttpClient Client { get; }
    string Key { get; }
}