using Multi_Layered_Architecture.CoreLayer;

namespace Multi_Layered_Architecture.DataAccessLayer
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync(); // Lấy tất cả phim
        Task<MoviesSeries> GetMovieByIdAsync(int id); // Lấy phim theo ID
        Task AddMovieAsync(MoviesSeries movie); // Thêm phim mới
        Task UpdateMovieAsync(MoviesSeries movie); // Cập nhật thông tin phim
        Task DeleteMovieAsync(int id); // Xóa phim theo ID
        Task<IEnumerable<MoviesSeries>> GetMoviesByGenreAsync(string genre); // Lấy phim theo thể loại
        Task<IEnumerable<MoviesSeries>> SearchMoviesAsync(string searchTerm); // Tìm kiếm phim theo từ khóa
    }
}
