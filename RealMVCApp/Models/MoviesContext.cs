using Microsoft.EntityFrameworkCore;

namespace RealMVCApp.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) 
        { 
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Category> Category { get; set; }

        //Setting the override to ensure the tables are pulled from Categories and Movies. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Movies>().ToTable("Movies");
        }

    }
}
