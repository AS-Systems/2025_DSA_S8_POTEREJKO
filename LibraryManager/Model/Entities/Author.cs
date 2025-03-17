using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class Author : Person
    {
        public ICollection<Book> Books { get; set; }
    }
}
