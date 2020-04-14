using System.Collections.Generic;
using System.Linq;
using MvcMovie.Service.Contract.Dtos;
using MvcMovie.Service.Infrastructure.Database;

namespace MvcMovie.Service.Api.Model
{
    public static class Mapper
    {
        public static Movie Map(MovieDto dto)
        {
            return new Movie
                {Genre = dto.Genre, Id = dto.Id, Price = dto.Price, ReleaseDate = dto.ReleaseDate, Title = dto.Title};
        }

        public static IEnumerable<MovieDto> Map(IEnumerable<Movie> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static MovieDto Map(Movie model)
        {
            return new MovieDto
                {Genre = model.Genre, Id = model.Id, Price = model.Price, ReleaseDate = model.ReleaseDate, Title = model.Title};
        }
    }
}