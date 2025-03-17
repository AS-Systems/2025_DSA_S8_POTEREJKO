using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Entities
{
    public class User : Person
    {
        public string Phone { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
