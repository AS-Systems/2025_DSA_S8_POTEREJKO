using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookshelfRepository
    {
        Task<bool> IsAnyBookshelfAsync();
        Task<IEnumerable<Bookshelf?>> GetAllBookshelvesAsync();
        Task<Bookshelf> GetBookshelfByIdAsync(int id);
        Task InsertAsync(Bookshelf bookshelf);
        Task UpdateAsync(Bookshelf bookshelf);
        Task DeleteAsync(Bookshelf bookshelf);
    }
}