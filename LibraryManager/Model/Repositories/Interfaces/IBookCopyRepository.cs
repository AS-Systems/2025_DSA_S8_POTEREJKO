
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories
{
    public interface IBookCopyRepository
    {
        Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync();
        Task<BookCopy?> GetBookCopyByIdAsync(int id);
        Task AddBookCopyAsync(BookCopy bookCopy);
        Task UpdateBookCopyAsync(BookCopy bookCopy);
        Task DeleteBookCopyAsync(int id);

    }
}
