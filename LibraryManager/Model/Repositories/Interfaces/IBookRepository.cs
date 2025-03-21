using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task InsertAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveAsync();
    }
}
