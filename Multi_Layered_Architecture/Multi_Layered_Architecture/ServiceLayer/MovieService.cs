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

        public async Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<MoviesSeries> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task AddMovieAsync(MoviesSeries movie)
        {
            // Có thể thêm logic kiểm tra trước khi thêm
            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task UpdateMovieAsync(MoviesSeries movie)
        {
            // Có thể thêm logic kiểm tra trước khi cập nhật
            await _movieRepository.UpdateMovieAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            // Có thể thêm logic kiểm tra trước khi xóa
            await _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<IEnumerable<MoviesSeries>> GetMoviesByGenreAsync(string genre)
        {
            return await _movieRepository.GetMoviesByGenreAsync(genre);
        }

        public async Task<IEnumerable<MoviesSeries>> SearchMoviesAsync(string searchTerm)
        {
            return await _movieRepository.SearchMoviesAsync(searchTerm);
        }
    }
}
