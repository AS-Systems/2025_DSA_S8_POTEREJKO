﻿using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private readonly HomelibraryContext _context;

        public BookshelfRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyBookshelfAsync()
        {
            return await _context.BookShelves.AnyAsync();
        }

        public async Task<IEnumerable<Bookshelf?>> GetAllBookshelvesAsync()
        {
            return await _context.BookShelves.Include(b => b.Shelves).ToListAsync();
        }

        public async Task<IEnumerable<Bookshelf>> GetBookshelfOfUserAsync(int userId)
        {
            return await _context.BookShelves.Where(b => b.OwnerId == userId).Include(b => b.Shelves).ToListAsync();
        }


        public async Task<Bookshelf> GetBookshelfByIdAsync(int id)
        {
            return await _context.BookShelves.Include(b => b.Shelves).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task InsertAsync(Bookshelf bookshelf)
        {
            await _context.BookShelves.AddAsync(bookshelf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bookshelf bookshelf)
        {
            _context.BookShelves.Update(bookshelf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bookshelf bookshelf)
        {
            _context.BookShelves.Remove(bookshelf);
            await _context.SaveChangesAsync();
        }
    }
}