using Multi_Layered_Architecture.CoreLayer;

namespace Multi_Layered_Architecture.ServiceLayer
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync(); // Lấy tất cả phim
        Task<Movie> GetMovieByIdAsync(int id); // Lấy phim theo ID
        Task AddMovieAsync(Movie movie); // Thêm phim mới
        Task UpdateMovieAsync(Movie movie); // Cập nhật thông tin phim
        Task DeleteMovieAsync(int id); // Xóa phim theo ID
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre); // Lấy phim theo thể loại
        Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm); // Tìm kiếm phim theo từ khóa
    }
}
