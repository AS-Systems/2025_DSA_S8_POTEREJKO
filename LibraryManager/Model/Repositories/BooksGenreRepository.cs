using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public class BookGenreRepository : IBooksGenreRepository
    {
        private readonly HomelibraryContext _context;

        public BookGenreRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyBookGenreAsync()
        {
            return await _context.BooksGenres.AnyAsync();
        }

        public async Task<IEnumerable<BooksGenre>> GetAllBookGenresAsync()
        {
            return await _context.BooksGenres.ToListAsync();
        }

        public async Task<BooksGenre?> GetBookGenreByIdAsync(int bookGenreId)
        {
            return await _context.BooksGenres.FirstOrDefaultAsync(bg => bg.Id == bookGenreId);
        }

        public async Task InsertAsync(BooksGenre bookGenre)
        {
            await _context.BooksGenres.AddAsync(bookGenre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BooksGenre bookGenre)
        {
            _context.BooksGenres.Update(bookGenre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BooksGenre bookGenre)
        {
            _context.BooksGenres.Remove(bookGenre);
            await _context.SaveChangesAsync();
        }
    }
}
