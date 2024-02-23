using Microsoft.EntityFrameworkCore;

namespace Mission6_Barlocker.Models
{
    public class MovieInputContext : DbContext 
    {
        public MovieInputContext(DbContextOptions<MovieInputContext> options) : base (options) 
        {
        }

        public DbSet <Movie> MovieInputs { get; set; }
        public DbSet <Category> Categories { get; set; }
    }
}