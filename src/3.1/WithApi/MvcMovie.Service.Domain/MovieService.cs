using System.Collections.Generic;
using System.Linq;
using MvcMovie.Service.Infrastructure.Database;

namespace MvcMovie.Service.Domain
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }

    public class MovieService : IMovieService
    {
        private readonly MvcMovieContext _context;

        public MovieService(MvcMovieContext context)
        {
            _context = context;
        }

        IEnumerable<Movie> IMovieService.GetAll()
        {
            return _context.Movie.ToList();
        }

        Movie IMovieService.Get(int id)
        {
            return _context.Movie.Find(id);
        }

        void IMovieService.Create(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        void IMovieService.Update(Movie movie)
        {
            _context.Movie.Update(movie);
            _context.SaveChanges();
        }

        void IMovieService.Delete(int id)
        {
            _context.Movie.Remove(_context.Movie.Find(id));
            _context.SaveChanges();
        }
    }
}