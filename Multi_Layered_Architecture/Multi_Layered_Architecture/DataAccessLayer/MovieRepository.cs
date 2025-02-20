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

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await _context.Movies
                .Where(m => m.Genre.ToLower() == genre.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm)
        {
            return await _context.Movies
                .Where(m => m.Title.ToLower().Contains(searchTerm.ToLower()) ||
                             m.Description.ToLower().Contains(searchTerm.ToLower()))
                .ToListAsync();
        }
    }
}
