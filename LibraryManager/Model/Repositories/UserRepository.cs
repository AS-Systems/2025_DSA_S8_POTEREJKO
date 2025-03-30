using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly LibraryDBContext _libraryDBContext;

        public UserRepository(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<IEnumerable<Entities.User>> GetAllUsersAsync()
        {
            return await _libraryDBContext.Users.ToListAsync();
        }

        public async Task<Entities.User?> GetUserByIdAsync(int userId)
        {
            return await _libraryDBContext.Users.FindAsync(userId);
        }

        public async Task<Entities.User?> GetUserByUsernameAsync(string username)
        {
            return await _libraryDBContext.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnyUserAsync()
        {
            return await _libraryDBContext.Users.AnyAsync();
        }
    }
}
