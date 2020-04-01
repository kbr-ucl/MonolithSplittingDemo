using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MvcMovie.Service.Contract.Dtos;
using MvcMovie.Service.Contract.Services;

namespace MvcMovie.Ui.Mvc.Services
{
    public class MovieServiceProxy : IMovieService
    {
        private const string _moviesRequestUri = "api/Movies";

        public MovieServiceProxy(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        async Task IMovieService.AddAsync(MovieDto movie)
        {
            var json = JsonSerializer.Serialize(movie);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_moviesRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task<MovieDto> IMovieService.GetMovieAsync(int id)
        {
            var response = await Client.GetAsync($"{_moviesRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<MovieDto>(stream, options).ConfigureAwait(false);
        }

        async Task<IEnumerable<MovieDto>> IMovieService.GetMoviesAsync()
        {
            var response = await Client.GetAsync(_moviesRequestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<MovieDto>>(stream, options).ConfigureAwait(false);
        }

        async Task IMovieService.RemoveAsync(int id)
        {
            var response = await Client.DeleteAsync($"{_moviesRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IMovieService.UpdateAsync(int id, MovieDto movie)
        {
            var json = JsonSerializer.Serialize(movie);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_moviesRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
    }
}