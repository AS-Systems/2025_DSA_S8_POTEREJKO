using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public int Number { get; set; }

        //Foregin key
        public int BookShelfId { get; set; }
        public BookShelf BookShelf { get; set; }
        public ICollection<Storage> Storages { get; set; }
    }
}
