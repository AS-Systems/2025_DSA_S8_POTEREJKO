﻿using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Helpers;
using LibraryManager.Model.Enums;

namespace LibraryManager.Model.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly HomelibraryContext _context;

        public UserRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyUserAsync()
        {
            return await _context.Users.AnyAsync();
        }

        public async Task<IEnumerable<Entities.User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Borrows)
                .Include(u => u.BookCopies)
                .ToListAsync();
        }

        public async Task<Entities.User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Borrows)
                .Include(u => u.BookCopies)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<Entities.User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }
        public async Task InsertAsync(Entities.User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entities.User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Entities.User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalBorrowsOfUserAsync(int userId, TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .CountAsync(b => b.UserId == userId && b.BorrowDate >= start && b.BorrowDate < end);
        }

        public async Task<int> GetTotalBorrowsAsync(TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .CountAsync(b => b.BorrowDate >= start && b.BorrowDate < end);
        }

    }
}
