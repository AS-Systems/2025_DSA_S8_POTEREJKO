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
        Task<bool> IsAnyBookAsync();
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
    }
}
