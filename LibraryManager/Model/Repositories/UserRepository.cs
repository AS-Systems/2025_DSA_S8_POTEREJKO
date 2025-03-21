using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    internal class UserRepository : Interfaces.IUserRepository
    {
        private readonly LibraryContext _context;
        public UserRepository(LibraryContext context)
        {
           _context = context; 
        }

        public async Task DeleteAsync(User user)
        {
            var userToDelete = await _context.Users.FindAsync(user.Id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Surname = user.Surname;
                userToUpdate.Phone = user.Phone;
                await SaveAsync();
            }
        }
    }
}
