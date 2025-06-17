using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookRepository
    {
        Task<bool> IsAnyBookAsync();
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task DeleteAsync(Book book);
        Task InsertAsync(Book book);
        Task UpdateAsync(Book book);
    }
}
