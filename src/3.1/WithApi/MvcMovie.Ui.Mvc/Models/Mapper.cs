using System.Collections.Generic;
using System.Linq;
using MvcMovie.Service.Contract.Dtos;

namespace MvcMovie.Ui.Mvc.Models
{
    public static class Mapper
    {
        public static MovieViewModel Map(MovieDto dto)
        {
            return new MovieViewModel
                {Genre = dto.Genre, Id = dto.Id, Price = dto.Price, ReleaseDate = dto.ReleaseDate, Title = dto.Title, RowVersion = dto.RowVersion};
        }

        public static IEnumerable<MovieViewModel> Map(IEnumerable<MovieDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable();
        }

        public static MovieDto Map(MovieViewModel view)
        {
            return new MovieDto
                {Genre = view.Genre, Id = view.Id, Price = view.Price, ReleaseDate = view.ReleaseDate, Title = view.Title, RowVersion = view.RowVersion};
        }
    }
}