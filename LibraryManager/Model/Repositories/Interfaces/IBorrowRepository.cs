using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Enums;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBorrowRepository
    {
        Task<int> GetTotalBorrowsOfUserAsync(int userId, TimePeriod timePeriod);
        Task<int> GetTotalBorrowsAsync(TimePeriod timePeriod);
        Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserAsync(int userId, TimePeriod timePeriod);
        Task<IEnumerable<Borrow>> GetUpcomingBorrowsAsync(TimePeriod timePeriod);
        Task<IEnumerable<Borrow>> GetUpcomingReturnsOfUserAsync(int userId, TimePeriod timePeriod);
        Task<IEnumerable<Borrow>> GetUpcomingReturnsAsync(TimePeriod timePeriod);
        Task<bool> IsAnyBorrowAsync();
        Task<IEnumerable<Borrow>> GetAllBorrowsAsync();
        Task<Borrow?> GetBorrowByIdAsync(int id);
        Task InsertAsync(Borrow borrow);
        Task UpdateAsync(Borrow borrow);
        Task DeleteAsync(Borrow borrow);
    }
}
