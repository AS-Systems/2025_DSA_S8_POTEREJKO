using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly HomelibraryContext _context;

        public ShelfRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyShelfAsync()
        {
            return await _context.Shelves.AnyAsync();
        }

        public async Task<IEnumerable<Shelf>> GetAllShelvesAsync()
        {
            return await _context.Shelves.ToListAsync();
        }

        public async Task<Shelf?> GetShelfByIdAsync(int id)
        {
            return await _context.Shelves.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Shelf>> GetAllShelvesOfBookshelfAsync(int bookshelfId)
        {
            return await _context.Shelves.Where(b => b.BookshelfId == bookshelfId).ToListAsync();
        }

        public async Task InsertAsync(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            _context.Shelves.Update(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Shelf shelf)
        {
            var entity = await _context.Shelves.FindAsync(shelf.Id);
            if (entity != null)
            {
                _context.Shelves.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}