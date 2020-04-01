using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public SelectList Genres;
        public List<Movie> Movies;
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}