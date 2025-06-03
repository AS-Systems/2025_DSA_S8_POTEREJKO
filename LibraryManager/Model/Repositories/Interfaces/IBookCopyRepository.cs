using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookCopyRepository
    {
        Task<bool> IsAnyBookCopyAsync();
        Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync();
        Task<BookCopy?> GetBookCopyByIdAsync(int bookCopyId);
        Task InsertAsync(BookCopy bookCopy);
        Task UpdateAsync(BookCopy bookCopy);
        Task DeleteAsync(BookCopy bookCopy);
    }
}
