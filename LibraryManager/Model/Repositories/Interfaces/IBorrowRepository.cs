using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBorrowRepository
    {
        Task<IEnumerable<Borrow>> GetAllAsync();
        Task<Borrow?> GetByIdAsync(int id);
        Task InsertAsync(Borrow loan);
        Task UpdateAsync(Borrow loan);
        Task DeleteAsync(Borrow loan);
        Task SaveAsync();
    }
}
