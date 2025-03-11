using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class Storage
    {
        public int Id { get; set; }

        //Foregin keys

        public ICollection<Book> Books { get; set; }

        public int BookShelfId { get; set; }
        public BookShelf BookShelf { get; set; }
        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }

    }
}
