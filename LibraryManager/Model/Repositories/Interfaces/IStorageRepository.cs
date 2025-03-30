using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IStorageRepository
    {
        Task<bool> IsAnySorageAsync();
        Task<Storage?> GetStorageByIdAsync(int id);
        Task<IEnumerable<Storage>> GetAllStoragesAsync();
    }
}
