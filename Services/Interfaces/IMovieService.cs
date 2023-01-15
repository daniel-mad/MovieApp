
using Shared.DTOs;

namespace Services.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMostPopularMovies();
    Task<MovieFullDetailsDto> GetMovieInformation(string movieId);
    Task<IEnumerable<MovieDto>> GetMoviesByName(string expression);
}
