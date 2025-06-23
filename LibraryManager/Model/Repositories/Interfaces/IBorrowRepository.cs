using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Model.Enums;

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
        Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserAsync(int userId, TimePeriod period);
        Task<IEnumerable<Borrow>> GetUpcomingBorrowsAsync(TimePeriod period);
        Task<IEnumerable<Borrow>> GetUpcomingReturnsOfUserAsync(int userId, TimePeriod period);
        Task<IEnumerable<Borrow>> GetUpcomingReturnsAsync(TimePeriod period);
        Task<List<Borrow>> GetAllBorrowsOfUserId2(int userId);
    }
}
