using System.Collections.Generic;
using System.Threading.Tasks;
using MvcMovie.Service.Contract.Dtos;

namespace MvcMovie.Service.Contract.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task AddAsync(MovieDto movie);
        Task UpdateAsync(int id, MovieDto movie);
        Task RemoveAsync(int id);
    }
}