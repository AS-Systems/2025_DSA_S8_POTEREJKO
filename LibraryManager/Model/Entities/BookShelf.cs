using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class BookShelf
    {
        public int Id { get; set; }
        public int BookShelfNumber { get; set; }

        //Foregin keys
        public ICollection<Shelf> Shelves { get; set; }
        public ICollection<Storage> Storages { get; set; }

    }
}
