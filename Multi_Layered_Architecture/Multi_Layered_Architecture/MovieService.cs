namespace Multi_Layered_Architecture.ServiceLayer.Services
{
    public class MovieService : IMovieService
    {
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            // Giả lập dữ liệu trả về
            return new List<Movie>
            {
                new Movie { Title = "Inception", Genre = "Sci-Fi" },
                new Movie { Title = "The Dark Knight", Genre = "Action" }
            };
        }
    }
}
