using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(Book book);
        void Save();

        
    }
}
