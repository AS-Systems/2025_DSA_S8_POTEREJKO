using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBorrowRepository
    {
        Task<bool> IsAnyBorrowAsync();
        Task<IEnumerable<Borrow>> GetAllBorrowsAsync();
        Task<Borrow?> GetBorrowByIdAsync(int id);
        Task InsertAsync(Borrow borrow);
        Task UpdateAsync(Borrow borrow);
        Task DeleteAsync(Borrow borrow);
    }
}
