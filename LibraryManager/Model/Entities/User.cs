using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class User : Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }


        //Foregin keys
        public int BorrowID { get; set; }
        public ICollection<Borrow> Borrows {  get; set; }   
    }
}
