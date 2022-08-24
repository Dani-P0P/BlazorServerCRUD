using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;

        public MovieService(DataContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public async Task AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("movies");
        }

        public async Task DeleteMovie(int id)
        {
            var dbMovie = await _context.Movies.FindAsync(id);
            if (dbMovie == null)
                throw new Exception("Movie not found.");

            _context.Movies.Remove(dbMovie);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("movies");
        }

        public async Task EditMovie(Movie movie, int id)
        {
            var dbMovie = await _context.Movies.FindAsync(id);
            if(dbMovie == null)
                throw new Exception("Movie not found.");
            dbMovie.Name = movie.Name;
            dbMovie.Company = movie.Company;
            dbMovie.ReleaseDate = movie.ReleaseDate;

            await _context.SaveChangesAsync();

            _navigationManager.NavigateTo("movies");
        }

        public async Task<Movie> ShowMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                throw new Exception("Movie not found.");
            return movie;
        }

        public async Task ShowMovies()
        {
            Movies = await _context.Movies.ToListAsync();
        }
    }
}
