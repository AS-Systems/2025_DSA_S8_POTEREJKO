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
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly HomelibraryContext _context;

        public BookAuthorRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyBookAuthorAsync()
        {
            return await _context.BookAuthors.AnyAsync();
        }

        public async Task<IEnumerable<BookAuthor>> GetAllBookAuthorsAsync()
        {
            return await _context.BookAuthors.ToListAsync();
        }

        public async Task<BookAuthor?> GetBookAuthorByIdAsync(int id)
        {
            return await _context.BookAuthors.FirstOrDefaultAsync(ba => ba.Id == id);
        }

        public async Task InsertAsync(BookAuthor bookAuthor)
        {
            await _context.BookAuthors.AddAsync(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Update(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();
        }
    }
}