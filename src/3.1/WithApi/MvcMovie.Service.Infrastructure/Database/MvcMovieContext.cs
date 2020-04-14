

// Enables public DbSet<Movie> Movie

using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Service.Infrastructure.Database
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