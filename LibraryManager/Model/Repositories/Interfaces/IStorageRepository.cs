using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IStorageRepository
    {
        Task<bool> IsAnyStorageAsync();
        Task<IEnumerable<Storage>> GetAllStoragesAsync();
        Task<Storage?> GetStorageByIdAsync(int id);
        Task InsertAsync(Storage storage);
        Task UpdateAsync(Storage storage);
        Task DeleteAsync(Storage storage);
    }
}