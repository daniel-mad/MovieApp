
using AutoMapper;
using Client.Clients;
using Entities.Exceptions;
using Entities.Models;
using Services.Interfaces;
using Shared.DTOs;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Services;

public class MovieService : IMovieService
{
    private readonly HttpClient _client;
    private readonly string _apiKey;
    private readonly IMapper _mapper;

    public MovieService(IIMDBClient client, IMapper mapper)
    {
        _client = client.Client;
        _apiKey = client.Key;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> GetMostPopularMovies()
    {
        var moviesFromApi = await _client.GetFromJsonAsync<MostPopularData>($"/API/MostPopularMovies/{_apiKey}");

        var movies = _mapper.Map<IEnumerable<MovieDto>>(moviesFromApi!.Items);
        return movies;

    }

    public async Task<IEnumerable<MovieDto>> GetMoviesByName(string expression)
    {
        var moviesSearchData = await _client.GetFromJsonAsync<SearchData>($"/API/SearchMovie/{_apiKey}/{expression}");
        var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(moviesSearchData.Results);
        return moviesDto;
    }

    public async Task<MovieFullDetailsDto> GetMovieInformation(string movieId)
    {
        var movie = await _client.GetFromJsonAsync<MovieFullDetailsDto>($"/API/Title/{_apiKey}/{movieId}");
        if (movie is null || string.IsNullOrEmpty(movie.Id))
        {
            throw new NotFoundException($"Movie with id {movieId} is not found.");
        }
        return movie;

    }
}
