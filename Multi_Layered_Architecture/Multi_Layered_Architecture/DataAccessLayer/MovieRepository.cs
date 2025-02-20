using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.CoreLayer;

namespace Multi_Layered_Architecture.DataAccessLayer
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MoviesSeries>> GetAllMoviesAsync()
        {
            return await _context.MoviesSeries.ToListAsync();
        }

        public async Task<MoviesSeries> GetMovieByIdAsync(int id)
        {
            return await _context.MoviesSeries.FindAsync(id);
        }

        public async Task AddMovieAsync(MoviesSeries movie)
        {
            await _context.MoviesSeries.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(MoviesSeries movie)
        {
            _context.MoviesSeries.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.MoviesSeries.FindAsync(id);
            if (movie != null)
            {
                _context.MoviesSeries.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MoviesSeries>> GetMoviesByGenreAsync(string genre)
        {
            return await _context.MoviesSeries
                .Where(m => m.Genre.ToLower() == genre.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<MoviesSeries>> SearchMoviesAsync(string searchTerm)
        {
            return await _context.MoviesSeries
                .Where(m => m.Title.ToLower().Contains(searchTerm.ToLower()) ||
                             m.Description.ToLower().Contains(searchTerm.ToLower()))
                .ToListAsync();
        }
    }
}
