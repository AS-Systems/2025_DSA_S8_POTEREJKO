using LibraryManager.Model.Entities;
using System.Collections.Generic;
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
        Task<IEnumerable<Borrow>> GetAllBorrowsOfUserId(int id);
        Task<IEnumerable<Borrow>> GetFinishedBorrowsOfUserId(int id);
        Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserId(int id);
        Task<IEnumerable<Borrow>> GetCurrentBorrowsOfUserId(int id);
    }
}
