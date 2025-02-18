using Microsoft.EntityFrameworkCore;

namespace RealMVCApp.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) 
        { 
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
