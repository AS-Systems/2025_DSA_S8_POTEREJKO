using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksOfUserAsync(int userId);
        Task<IEnumerable<Book>> GetAllAvailableBooksOfUserAsync(int userId);
        Task<IEnumerable<Book>> GetAllAvailableBooksAsync();
        Task<bool> IsAnyBookAsync();
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task InsertAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }
}
