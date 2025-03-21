using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task InsertAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(Loan loan);
        Task SaveAsync();
    }
}
