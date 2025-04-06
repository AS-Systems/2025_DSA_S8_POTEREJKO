using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IShelfRepository
    {
        Task<bool> IsAnyShelfAsync();
        Task<IEnumerable<Shelf>> GetAllShelvesAsync();
        Task<Shelf?> GetShelfByIdAsync(int id);
        Task InsertAsync(Shelf shelf);
        Task UpdateAsync(Shelf shelf);
        Task DeleteAsync(Shelf shelf);
    }
}