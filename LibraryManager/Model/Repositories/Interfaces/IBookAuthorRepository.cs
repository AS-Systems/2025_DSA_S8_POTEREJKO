using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories
{
    public interface IBookAuthorRepository
    {
        Task<IEnumerable<BookAuthor>> GetAllAsync();
        Task<BookAuthor?> GetAsync(int bookId, int authorId);
        Task<IEnumerable<BookAuthor>> GetByBookIdAsync(int bookId);
        Task<IEnumerable<BookAuthor>> GetByAuthorIdAsync(int authorId);
        Task AddAsync(BookAuthor bookAuthor);
        Task DeleteAsync(int bookId, int authorId);
        Task<bool> ExistsAsync(int bookId, int authorId);
    }
}
