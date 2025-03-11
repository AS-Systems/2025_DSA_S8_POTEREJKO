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

        //Foregin keys
        public int AuthorId { get; set; }
        public int StorageId { get; set; }

    }
}
