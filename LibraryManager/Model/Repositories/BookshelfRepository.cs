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
    internal class BookshelfRepository : IBookshelfRepository
    {
        private readonly LibraryDBContext _libraryDBContext;

        public BookshelfRepository(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<IEnumerable<Bookshelf>> GetAllBookshelvesAsync()
        {
            return await _libraryDBContext.Bookshelves.ToListAsync();
        }

        public async Task<Bookshelf?> GetBookshelfByIdAsync(int id)
        {
            return await _libraryDBContext.Bookshelves.FindAsync(id);
        }

        public async Task<bool> IsAnyBookshelfAsync()
        {
            return await _libraryDBContext.Bookshelves.AnyAsync();
        }
    }
}
