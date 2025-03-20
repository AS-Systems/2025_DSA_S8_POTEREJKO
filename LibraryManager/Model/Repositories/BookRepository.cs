using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories
{
    internal class BookRepository : Interfaces.IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
           _context = context; 
        }
        public void Delete(Book book)
        {
            var bookToDelete = _context.Books.Find(book.Id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public Book GetById(int id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        public void Insert(Book book)
        {
            _context.Books.Add(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            var bookToUpdate = _context.Books.Find(book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.PageCount = book.PageCount;
                bookToUpdate.AuthorId = book.AuthorId;
                bookToUpdate.StorageId = book.StorageId;
                bookToUpdate.LoanID = book.LoanID;
                _context.SaveChanges();
            }
        }
    }
}
