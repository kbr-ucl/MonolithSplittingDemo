using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Ui.Mvc.Models
{
    public class MovieGenreViewModel
    {
        public List<MovieViewModel> Movies;
        public SelectList Genres;
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}