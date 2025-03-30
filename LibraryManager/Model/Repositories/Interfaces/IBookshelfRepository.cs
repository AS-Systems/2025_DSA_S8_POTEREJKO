using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookshelfRepository
    {
        Task<bool> IsAnyBookshelfAsync();
        Task<IEnumerable<Bookshelf?>> GetAllBookshelvesAsync();
        Task<Bookshelf> GetBookshelfByIdAsync(int id);
    }
}
