﻿using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LibraryManager.Model.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly HomelibraryContext _context;

        public BookRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyBookAsync()
        {
            return await _context.Books.AnyAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author).Include(b => b.BookCopies).Include(b => b.BooksGenres).ThenInclude(bg => bg.Genre).ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author).Include(b => b.BookCopies).Include(b => b.BooksGenres).ThenInclude(bg => bg.Genre).FirstOrDefaultAsync(b => b.Id == id);
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
 
        public async Task<List<Book>> GetAllBooksOfUserAsync(int userId)
        {
            return await _context.BookCopies
                .AsNoTracking()
                .Where(bc => bc.OwnerId == userId)
                .Include(bc => bc.Book)
                .Select(bc => bc.Book)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Book>> GetAllAvailableBooksOfUserAsync(int userId)
        {
            return await _context.BookCopies
                .AsNoTracking()
                .Where(bc => bc.OwnerId == userId && bc.IsAvailable)
                .Include(bc => bc.Book)
                .Select(bc => bc.Book)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Book>> GetAllAvailableBooksAsync()
        {
            return await _context.BookCopies
                .AsNoTracking()
                .Where(bc => bc.IsAvailable)
                .Include(bc => bc.Book)
                .Select(bc => bc.Book)
                .Distinct()
                .ToListAsync();
        }

    }
}
