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
    internal class StorageRepository : IStorageRepository
    {
        private readonly LibraryDBContext _libraryDBContext;

        public StorageRepository(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<IEnumerable<Storage>> GetAllStoragesAsync()
        {
            return await _libraryDBContext.Storages.ToListAsync();
        }

        public async Task<Storage?> GetStorageByIdAsync(int id)
        {
            return await _libraryDBContext.Storages.FindAsync(id);
        }

        public async Task<bool> IsAnySorageAsync()
        {
            return await _libraryDBContext.Storages.AnyAsync();
        }
    }
}
