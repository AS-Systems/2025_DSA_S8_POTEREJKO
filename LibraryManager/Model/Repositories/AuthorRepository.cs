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
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDBContext _libraryDBContext;

        public AuthorRepository(LibraryDBContext libraryDBContext) 
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _libraryDBContext.Authors.ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _libraryDBContext.Authors.FindAsync(id);
        }

        public async Task<bool> IsAnyAuthorAsync()
        {
            return await _libraryDBContext.Authors.AnyAsync();
        }
    }
}
