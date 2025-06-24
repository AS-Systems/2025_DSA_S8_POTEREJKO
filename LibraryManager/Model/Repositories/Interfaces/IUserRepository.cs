using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Enums;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        Task<bool> IsAnyUserAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByUsernameAsync(string username);
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<int> GetTotalBorrowsOfUserAsync(int userId, TimePeriod period);
        Task<int> GetTotalBorrowsAsync(TimePeriod period);
    }
}
