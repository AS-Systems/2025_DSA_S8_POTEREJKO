using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly HomelibraryContext _libraryDBContext;

        public AuthorRepository(HomelibraryContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }

        public async Task<bool> IsAnyAuthorAsync()
        {
            return await _libraryDBContext.Authors.AnyAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _libraryDBContext.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _libraryDBContext.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task InsertAsync(Author author)
        {
            await _libraryDBContext.Authors.AddAsync(author);
            await _libraryDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _libraryDBContext.Authors.Update(author);
            await _libraryDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _libraryDBContext.Authors.Remove(author);
            await _libraryDBContext.SaveChangesAsync();
        }
    }
}