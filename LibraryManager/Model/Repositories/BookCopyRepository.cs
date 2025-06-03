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
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly HomelibraryContext _context;

        public BookCopyRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyBookCopyAsync()
        {
            return await _context.BookCopies.AnyAsync();
        }

        public async Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync()
        {
            return await _context.BookCopies.ToListAsync();
        }

        public async Task<BookCopy?> GetBookCopyByIdAsync(int bookCopyId)
        {
            return await _context.BookCopies.FirstOrDefaultAsync(bc => bc.Id == bookCopyId);
        }

        public async Task InsertAsync(BookCopy bookCopy)
        {
            await _context.BookCopies.AddAsync(bookCopy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookCopy bookCopy)
        {
            _context.BookCopies.Update(bookCopy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BookCopy bookCopy)
        {
            _context.BookCopies.Remove(bookCopy);
            await _context.SaveChangesAsync();
        }
    }
}