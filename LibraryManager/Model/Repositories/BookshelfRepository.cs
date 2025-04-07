using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private readonly LibraryDBContext _context;

        public BookshelfRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyBookshelfAsync()
        {
            return await _context.Bookshelves.AnyAsync();
        }

        public async Task<IEnumerable<Bookshelf?>> GetAllBookshelvesAsync()
        {
            return await _context.Bookshelves.Include(b => b.Shelves).ToListAsync();
        }

        public async Task<Bookshelf> GetBookshelfByIdAsync(int id)
        {
            return await _context.Bookshelves.Include(b => b.Shelves).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task InsertAsync(Bookshelf bookshelf)
        {
            await _context.Bookshelves.AddAsync(bookshelf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bookshelf bookshelf)
        {
            _context.Bookshelves.Update(bookshelf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bookshelf bookshelf)
        {
            _context.Bookshelves.Remove(bookshelf);
            await _context.SaveChangesAsync();
        }
    }
}