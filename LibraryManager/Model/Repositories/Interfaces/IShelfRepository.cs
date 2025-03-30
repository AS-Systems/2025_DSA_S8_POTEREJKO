using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IShelfRepository
    {
        Task<bool> IsAnyShelfAsync();
        Task<IEnumerable<Shelf>> GetAllShelvesAsync();
        Task<Shelf?> GetShelfByIdAsync(int id);
    }
}
