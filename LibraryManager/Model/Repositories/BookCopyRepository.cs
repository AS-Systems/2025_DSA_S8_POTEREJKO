using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    internal class BookCopyRepository : IBookCopyRepository
    {
        private readonly HomelibraryContext _libraryDBContext;

        public BookCopyRepository(HomelibraryContext context)
        {
            _libraryDBContext = context;

        }

        public async Task<IEnumerable<BookCopy>> GetAllBookCopiesAsync()
        {

            return await _libraryDBContext.BookCopies
                .Include(bc => bc.Book)
                .Include(bc => bc.Owner)
                .Include(bc => bc.Shelf)
                .Include(bc => bc.Shelf.Bookshelf)
                .Include(bc => bc.Borrows)
                .ToListAsync();
        }

        public async Task<BookCopy?> GetBookCopyByIdAsync(int id)
        {
            return await _libraryDBContext.BookCopies
                .Include(bc => bc.Book)
                .Include(bc => bc.Owner)
                .Include(bc => bc.Shelf)
                .Include(bc => bc.Shelf.Bookshelf)
                .Include(bc => bc.Borrows)
                .FirstOrDefaultAsync(bc => bc.Id == id);
        }

        public async Task<IEnumerable<BookCopy>> GetAllBookCopiesOfUserAsync(int ownerId)
        {
            return await _libraryDBContext.BookCopies
                   .Where(bc => bc.Owner.Id ==  ownerId)
                   .Include(bc => bc.Book)
                   .Include(bc => bc.Owner)
                   .Include(bc => bc.Shelf)
                   .Include(bc => bc.Shelf.Bookshelf)
                   .Include(bc => bc.Borrows)
                   .ToListAsync();
        }



        public async Task AddBookCopyAsync(BookCopy bookCopy)
        {
            _libraryDBContext.BookCopies.Add(bookCopy);
            await _libraryDBContext.SaveChangesAsync();
        }

        public async Task UpdateBookCopyAsync(BookCopy bookCopy)
        {
            _libraryDBContext.BookCopies.Update(bookCopy);
            await _libraryDBContext.SaveChangesAsync();
        }

        public async Task DeleteBookCopyAsync(int id)
        {
            var bookCopy = await _libraryDBContext.BookCopies.FindAsync(id);
            if (bookCopy != null)
            {
                _libraryDBContext.BookCopies.Remove(bookCopy);
                await _libraryDBContext.SaveChangesAsync();
            }
        }
    }
}
