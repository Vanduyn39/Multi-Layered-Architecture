namespace Multi_Layered_Architecture
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
    }
}
