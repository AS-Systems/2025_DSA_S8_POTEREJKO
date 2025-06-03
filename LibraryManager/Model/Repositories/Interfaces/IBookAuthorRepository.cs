using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookAuthorRepository
    {
        Task<bool> IsAnyBookAuthorAsync();
        Task<IEnumerable<BookAuthor>> GetAllBookAuthorsAsync();
        Task<BookAuthor?> GetBookAuthorByIdAsync(int bookAuthorId);
        Task InsertAsync(BookAuthor bookAuthor);
        Task UpdateAsync(BookAuthor bookAuthor);
        Task DeleteAsync(BookAuthor bookAuthor);
    }
}