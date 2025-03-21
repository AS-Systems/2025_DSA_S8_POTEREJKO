using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    internal class BookRepository : Interfaces.IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
           _context = context; 
        }

        public async Task DeleteAsync(Book book)
        {
            var bookToDelete = await _context.Books.FindAsync(book.Id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task InsertAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var bookToUpdate = await _context.Books.FindAsync(book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.PageCount = book.PageCount;
                bookToUpdate.LoanID = book.LoanID;
                bookToUpdate.AuthorId = book.AuthorId;
                bookToUpdate.StorageId = book.StorageId;
                await SaveAsync();
            }
        }
    }
}
