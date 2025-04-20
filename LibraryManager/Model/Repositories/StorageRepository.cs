using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly HomelibraryContext _context;

        public StorageRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyStorageAsync()
        {
            return await _context.Storages.AnyAsync();
        }

        public async Task<IEnumerable<Storage>> GetAllStoragesAsync()
        {
            return await _context.Storages.ToListAsync();
        }

        public async Task<Storage?> GetStorageByIdAsync(int id)
        {
            return await _context.Storages.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task InsertAsync(Storage storage)
        {
            await _context.Storages.AddAsync(storage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Storage storage)
        {
            _context.Storages.Update(storage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Storage storage)
        {
            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();
        }
    }
}