using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public class BooksGenreRepository : IBooksGenreRepository
    {
        private readonly HomelibraryContext _context;

        public BooksGenreRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BooksGenre>> GetAllAsync()
        {
            return await _context.BooksGenres
                .Include(bg => bg.Book)
                .Include(bg => bg.Genre)
                .ToListAsync();
        }

        public async Task<BooksGenre?> GetAsync(int bookId, int genreId)
        {
            return await _context.BooksGenres
                .Include(bg => bg.Book)
                .Include(bg => bg.Genre)
                .FirstOrDefaultAsync(bg => bg.BookId == bookId && bg.GenreId == genreId);
        }

        public async Task<IEnumerable<BooksGenre>> GetByBookIdAsync(int bookId)
        {
            return await _context.BooksGenres
                .Include(bg => bg.Genre)
                .Where(bg => bg.BookId == bookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BooksGenre>> GetByGenreIdAsync(int genreId)
        {
            return await _context.BooksGenres
                .Include(bg => bg.Book)
                .Where(bg => bg.GenreId == genreId)
                .ToListAsync();
        }

        public async Task AddAsync(BooksGenre booksGenre)
        {
            _context.BooksGenres.Add(booksGenre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bookId, int genreId)
        {
            var booksGenre = await _context.BooksGenres
                .FirstOrDefaultAsync(bg => bg.BookId == bookId && bg.GenreId == genreId);

            if (booksGenre != null)
            {
                _context.BooksGenres.Remove(booksGenre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int bookId, int genreId)
        {
            return await _context.BooksGenres
                .AnyAsync(bg => bg.BookId == bookId && bg.GenreId == genreId);
        }
    }
}
