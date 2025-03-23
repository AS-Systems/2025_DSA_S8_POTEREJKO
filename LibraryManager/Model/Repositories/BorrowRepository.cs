using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    internal class BorrowRepository : Interfaces.IBorrowRepository
    {
        private readonly LibraryContext _context;
        public BorrowRepository(LibraryContext context)
        {
           _context = context; 
        }
       public async Task DeleteAsync(Borrow borrow)
        {
            var borrowToDelete = await _context.Borrows.FindAsync(borrow.Id);
            if (borrowToDelete != null)
            {
                _context.Borrows.Remove(borrowToDelete);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<Borrow>> GetAllAsync()
        {
            return await _context.Borrows.ToListAsync();
        }

        public async Task<Borrow?> GetByIdAsync(int id)
        {
            return await _context.Borrows.FindAsync(id);
        }

        public async Task InsertAsync(Borrow borrow)
        {
            await _context.Borrows.AddAsync(borrow);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrow borrow)
        {
            var borrowToUpdate = await _context.Borrows.FindAsync(borrow.Id);
            if (borrowToUpdate != null)
            {
                borrowToUpdate.TakeDate = borrow.TakeDate;
                borrowToUpdate.ReturnDate = borrow.ReturnDate;
                borrowToUpdate.BookId = borrow.BookId;
                borrowToUpdate.UserId = borrow.UserId;
		await SaveAsync();
            }
        }
    }
}
