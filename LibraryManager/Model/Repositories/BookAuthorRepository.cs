
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibraryManager.Model.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly HomelibraryContext _context;

        public BookAuthorRepository(HomelibraryContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<BookAuthor>> GetAllAsync()
        {
            return await _context.BookAuthors
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .ToListAsync();
        }

        public async Task<BookAuthor?> GetAsync(int bookId, int authorId)
        {
            return await _context.BookAuthors
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .FirstOrDefaultAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);
        }

        public async Task<IEnumerable<BookAuthor>> GetByBookIdAsync(int bookId)
        {
            return await _context.BookAuthors
                .Include(ba => ba.Author)
                .Where(ba => ba.BookId == bookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookAuthor>> GetByAuthorIdAsync(int authorId)
        {
            return await _context.BookAuthors
                .Include(ba => ba.Book)
                .Where(ba => ba.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task AddAsync(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bookId, int authorId)
        {
            var bookAuthor = await _context.BookAuthors
                .FirstOrDefaultAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);

            if (bookAuthor != null)
            {
                _context.BookAuthors.Remove(bookAuthor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int bookId, int authorId)
        {
            return await _context.BookAuthors
                .AnyAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);
        }
    }
}

