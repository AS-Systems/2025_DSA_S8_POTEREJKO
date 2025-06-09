using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Enums;

namespace LibraryManager.Model.Repositories
{
    internal class BorrowRepository : IBorrowRepository
    {
        private readonly HomelibraryContext _context;

        public BorrowRepository(HomelibraryContext context)
        {
            _context = context;
        }
        
        public async Task<int> GetTotalBorrowsOfUserAsync(int userId, TimePeriod timePeriod)
        {
            var startDate = GetStartDate(timePeriod);
            return await _context.Borrows
                .Where(b => b.UserId == userId && b.BorrowDate >= startDate)
                .AsNoTracking()
                .CountAsync();
        }
        
        public async Task<int> GetTotalBorrowsAsync(TimePeriod timePeriod)
        {
            var startDate = GetStartDate(timePeriod);
            return await _context.Borrows
                .Where(b => b.BorrowDate >= startDate)
                .AsNoTracking()
                .CountAsync();
        }
        
        public async Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserAsync(int userId, TimePeriod timePeriod)
        {
            var startDate = DateTime.UtcNow;
            var endDate = GetEndDate(timePeriod);
            return await _context.Borrows
                .Where(b => b.UserId == userId && b.BorrowDate >= startDate && b.BorrowDate <= endDate)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Borrow>> GetUpcomingBorrowsAsync(TimePeriod timePeriod)
        {
            var startDate = DateTime.UtcNow;
            var endDate = GetEndDate(timePeriod);
            return await _context.Borrows
                .Where(b => b.BorrowDate >= startDate && b.BorrowDate <= endDate)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Borrow>> GetUpcomingReturnsOfUserAsync(int userId, TimePeriod timePeriod)
        {
            var startDate = DateTime.UtcNow;
            var endDate = GetEndDate(timePeriod);
            return await _context.Borrows
                .Where(b => b.UserId == userId && b.ReturnDate >= startDate && b.ReturnDate <= endDate)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Borrow>> GetUpcomingReturnsAsync(TimePeriod timePeriod)
        {
            var startDate = DateTime.UtcNow;
            var endDate = GetEndDate(timePeriod);
            return await _context.Borrows
                .Where(b => b.ReturnDate >= startDate && b.ReturnDate <= endDate)
                .AsNoTracking()
                .ToListAsync();
        }
        
        private DateTime GetStartDate(TimePeriod timePeriod)
        {
            return timePeriod switch
            {
                TimePeriod.Today => DateTime.UtcNow.Date,
                TimePeriod.ThisMonth => new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1),
                TimePeriod.ThisYear => new DateTime(DateTime.UtcNow.Year, 1, 1),
                _ => throw new ArgumentOutOfRangeException(nameof(timePeriod), "Invalid time period")
            };
        }
        
        private DateTime GetEndDate(TimePeriod timePeriod)
        {
            return timePeriod switch
            {
                TimePeriod.Today => DateTime.UtcNow.Date.AddDays(1).AddTicks(-1),
                TimePeriod.ThisMonth => new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1).AddMonths(1).AddTicks(-1),
                TimePeriod.ThisYear => new DateTime(DateTime.UtcNow.Year, 1, 1).AddYears(1).AddTicks(-1),
                _ => throw new ArgumentOutOfRangeException(nameof(timePeriod), "Invalid time period")
            };
        }
        
        public async Task<bool> IsAnyBorrowAsync()
        {
            return await _context.Borrows.AnyAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAllBorrowsAsync()
        {
            return await _context.Borrows.Include(b => b.User).ToListAsync();
        }

        public async Task<Borrow?> GetBorrowByIdAsync(int id)
        {
            return await _context.Borrows.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task InsertAsync(Borrow borrow)
        {
            await _context.Borrows.AddAsync(borrow);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrow borrow)
        {
            _context.Borrows.Update(borrow);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Borrow borrow)
        {
            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();
        }
 
    }
}
