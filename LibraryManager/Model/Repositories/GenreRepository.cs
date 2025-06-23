
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly HomelibraryContext _context;

        public GenreRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres
                .Include(g => g.BooksGenres)
                    .ThenInclude(bg => bg.Book)
                .ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres
                .Include(g => g.BooksGenres)
                    .ThenInclude(bg => bg.Book)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Genres.AnyAsync(g => g.Id == id);
        }
        public async Task<IEnumerable<Genre>> GetTopGenresAsync(int top = 3)
        {
            return await _context.Genres
                .Include(g => g.BooksGenres)
                .OrderByDescending(g => g.BooksGenres.Count)
                .Take(top)
                .ToListAsync();
        }

    }
}
