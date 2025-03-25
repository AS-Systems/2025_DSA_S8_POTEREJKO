using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBorrowerRepository
    {
        Task<IEnumerable<Borrower>> GetAllAsync();
        Task<Borrower?> GetByIdAsync(int id);
        Task InsertAsync(Borrower borrower);
        Task UpdateAsync(Borrower borrower);
        Task DeleteAsync(Borrower borrower);
        Task SaveAsync();
    }
}
