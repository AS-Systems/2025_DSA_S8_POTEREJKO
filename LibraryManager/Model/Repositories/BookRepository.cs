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
    internal class BookRepository : IBookRepository
    {
        private readonly HomelibraryContext _context;

        public BookRepository(HomelibraryContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Book>> GetAllBooksOfUserAsync(int userId)
        {
            return await _context.Books
                .Where(b => b.Id == userId) //assuming userId is a book ID here, which is not typical imo \o/
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Book>> GetAllAvailableBooksOfUserAsync(int userId)
        {
            return await _context.Books
                .Where(b => b.Id == userId && b.IsAvailable) //same here. but isAvailable is not a property of book
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Book>> GetAllAvailableBooksAsync()
        {
            return await _context.Books
                .Where(b => b.IsAvailable) //and same here
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<bool> IsAnyBookAsync()
        {
            return await _context.Books.AnyAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.BookAuthors).Include(b => b.BookCopies).ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.BookAuthors).Include(b => b.BookCopies).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task InsertAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        } 
    }
}
