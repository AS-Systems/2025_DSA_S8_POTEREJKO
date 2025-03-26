using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public bool IsAvailable { get; set; } = true; // Default value

        //Foregin keys
        public int BorrowID { get; set; }
        public ICollection<Borrow> Borrows {  get; set; }   

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
