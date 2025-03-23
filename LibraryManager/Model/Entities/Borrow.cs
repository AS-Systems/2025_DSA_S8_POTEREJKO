using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class Borrow
    {
        public int Id { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }

        //Foregin keys
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
