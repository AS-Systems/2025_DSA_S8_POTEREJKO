using LibraryManager.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Model.Repositories
{
    public interface IBooksGenreRepository
    {
        Task<IEnumerable<BooksGenre>> GetAllAsync();
        Task<BooksGenre?> GetAsync(int bookId, int genreId);
        Task<IEnumerable<BooksGenre>> GetByBookIdAsync(int bookId);
        Task<IEnumerable<BooksGenre>> GetByGenreIdAsync(int genreId);
        Task AddAsync(BooksGenre booksGenre);
        Task DeleteAsync(int bookId, int genreId);
        Task<bool> ExistsAsync(int bookId, int genreId);
    }
}
