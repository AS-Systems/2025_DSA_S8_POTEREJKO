using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    internal class BorrowerRepository : Interfaces.IBorrowerRepository
    {
        private readonly LibraryContext _context;
        public BorrowerRepository(LibraryContext context)
        {
           _context = context; 
        }
       public async Task DeleteAsync(Borrower borrower)
       { 
            var borrowerToDelete = await _context.Borrowers.FindAsync(borrower.Id);
            if (borrowerToDelete != null)
            {
                _context.Borrowers.Remove(borrowerToDelete);
                await SaveAsync();
            }
       }

        public async Task<IEnumerable<Borrower>> GetAllAsync()
        {
            return await _context.Borrowers.ToListAsync();
        }

        public async Task<Borrower?> GetByIdAsync(int id)
        {
            return await _context.Borrowers.FindAsync(id);
        }

        public async Task InsertAsync(Borrower borrower)
        {
            await _context.Borrowers.AddAsync(borrower);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrower borrower)
        {
            var borrowerToUpdate = await _context.Borrowers.FindAsync(borrower.Id);
            if (borrowerToUpdate != null)
            { 
                borrowerToUpdate.Surname = borrower.Surname;
                borrowerToUpdate.Phone = borrower.Phone;
                await SaveAsync();
            }
        }
    }
}
