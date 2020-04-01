using Microsoft.EntityFrameworkCore;

// Enables public DbSet<Movie> Movie

namespace MvcMovie.Service.Api.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext()
        {
            
        }
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}