using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<bool> IsAnyAuthorAsync();
        Task InsertAsync(Author author);
        Task UpdateAsync(Author author);
    }
}
