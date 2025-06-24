using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Model.Helpers;
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

        public async Task<bool> IsAnyBorrowAsync()
        {
            return await _context.Borrows.AnyAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAllBorrowsAsync()
        {
            return await _context.Borrows.Include(b => b.User).ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAllBorrowsOfUserId(int id)
        {
            return await _context.Borrows
                .Where(b => b.UserId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetFinishedBorrowsOfUserId(int id)
        {
            return await _context.Borrows
                .Where(b => b.UserId == id && b.ReturnDate.HasValue && b.ReturnDate.Value < DateTime.Now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserId(int id)
        {
            return await _context.Borrows
                .Where(b => b.UserId == id && b.BorrowDate.HasValue && b.BorrowDate.Value > DateTime.Now)
                .ToListAsync();
        }

        public async Task<Borrow?> GetBorrowByIdAsync(int id)
        {
            return await _context.Borrows
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
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

        public async Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserAsync(int userId, TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.UserId == userId
                            && b.BorrowDate.HasValue
                            && b.BorrowDate.Value >= start
                            && b.BorrowDate.Value < end)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetUpcomingBorrowsAsync(TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.BorrowDate.HasValue
                            && b.BorrowDate.Value >= start
                            && b.BorrowDate.Value < end)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetUpcomingReturnsOfUserAsync(int userId, TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.UserId == userId
                            && b.ReturnDate.HasValue
                            && b.ReturnDate.Value >= start
                            && b.ReturnDate.Value < end)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetUpcomingReturnsAsync(TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.ReturnDate.HasValue
                            && b.ReturnDate.Value >= start
                            && b.ReturnDate.Value < end)
                .ToListAsync();
        }

        public async Task<List<Borrow>> GetAllBorrowsOfUserId2(int userId)
        {
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }
        public async Task<List<Borrow>> GetTrueUpcomingBorrowsAsync(TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetUpcomingRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.BorrowDate.HasValue
                            && b.BorrowDate.Value >= start
                            && b.BorrowDate.Value < end)
                .ToListAsync();
        }
        public async Task<List<Borrow>> GetTrueUpcomingReturnsAsync(TimePeriod period)
        {
            var (start, end) = TimePeriodHelper.GetUpcomingRange(period);
            return await _context.Borrows
                .AsNoTracking()
                .Where(b => b.ReturnDate.HasValue
                            && b.ReturnDate.Value >= start
                            && b.ReturnDate.Value < end)
                .ToListAsync();
        }
    }
}

