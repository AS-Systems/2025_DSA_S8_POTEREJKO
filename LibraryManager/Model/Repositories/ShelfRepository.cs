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
    internal class ShelfRepository : IShelfRepository
    {
        private readonly LibraryDBContext _libraryDBContext;

        public ShelfRepository(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<IEnumerable<Shelf>> GetAllShelvesAsync()
        {
            return await _libraryDBContext.Shelves.ToListAsync();
        }

        public async Task<Shelf?> GetShelfByIdAsync(int id)
        {
            return await _libraryDBContext.Shelves.FindAsync(id);
        }

        public async Task<bool> IsAnyShelfAsync()
        {
            return await _libraryDBContext.Shelves.AnyAsync();
        }
    }
}
