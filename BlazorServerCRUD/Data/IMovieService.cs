namespace BlazorServerCRUD.Data
{
    public interface IMovieService
    {
        List<Movie> Movies { get; set; }
        Task ShowMovies();
        Task<Movie> ShowMovie(int id);
        Task AddMovie(Movie movie);
        Task EditMovie(Movie movie, int id);
        Task DeleteMovie(int id);
    }
}
