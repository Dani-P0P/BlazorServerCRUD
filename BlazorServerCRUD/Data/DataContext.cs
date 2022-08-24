using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                    new Movie { Id=1, Name="Tomb Raider", Company="Warner Bros. Pictures", ReleaseDate= new DateTime(2018, 3, 2) },
                    new Movie { Id = 2, Name = "Assassin's Creed", Company = "Ubisoft Motion Pictures", ReleaseDate = new DateTime(2016, 12, 13) }
                );
        }

        public DbSet<Movie> Movies => Set<Movie>();
    }
}
