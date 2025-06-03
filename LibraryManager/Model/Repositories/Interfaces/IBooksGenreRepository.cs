using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBooksGenreRepository
    {
        Task<bool> IsAnyBookGenreAsync();
        Task<IEnumerable<BooksGenre>> GetAllBookGenresAsync();
        Task<BooksGenre?> GetBookGenreByIdAsync(int bookGenreId);
        Task InsertAsync(BooksGenre bookGenre);
        Task UpdateAsync(BooksGenre bookGenre);
        Task DeleteAsync(BooksGenre bookGenre);
    }
}