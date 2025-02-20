using Multi_Layered_Architecture.CoreLayer;
using Multi_Layered_Architecture.DataAccessLayer;

namespace Multi_Layered_Architecture.ServiceLayer
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            // Có thể thêm logic kiểm tra trước khi thêm
            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            // Có thể thêm logic kiểm tra trước khi cập nhật
            await _movieRepository.UpdateMovieAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            // Có thể thêm logic kiểm tra trước khi xóa
            await _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await _movieRepository.GetMoviesByGenreAsync(genre);
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm)
        {
            return await _movieRepository.SearchMoviesAsync(searchTerm);
        }
    }
}
