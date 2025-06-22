using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await _context.Borrows.Where(b => b.UserId == id).ToListAsync();  
        }

        public async Task<IEnumerable<Borrow>> GetFinishedBorrowsOfUserId(int id)
        { 
            return await _context.Borrows.Where(b => b.UserId == id && b.Status == (sbyte)Status.Finished)
                .Include(b => b.BookCopy.Book)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetUpcomingBorrowsOfUserId(int id)
        {
            return await _context.Borrows.Where(b => b.UserId == id && b.Status == (sbyte)Status.Upcomming)
                .Include(b => b.BookCopy.Book)
                .Include(b =>b.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetCurrentBorrowsOfUserId(int id)
        {
            return await _context.Borrows.Where(b => b.UserId == id && b.Status == (sbyte)Status.Current).ToListAsync();
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
