using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    internal class BorrowRepository : IBorrowRepository
    {
        private readonly LibraryDBContext _libraryDBContext;

        public BorrowRepository(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<IEnumerable<Borrow>> GetAllBorrowsAsync()
        {
            return await _libraryDBContext.Borrows.ToListAsync();
        }

        public async Task<Borrow?> GetBorrowByIdAsync(int id)
        {
            return await _libraryDBContext.Borrows.FindAsync(id);
        }

        public async Task<bool> IsAnyBorrowAsync()
        {
            return await _libraryDBContext.Borrows.AnyAsync();
        }
    }
}
