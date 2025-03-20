using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface ILoanRepository
    {
        IEnumerable<Loan> GetAll();
        Loan GetById(int id);
        void Insert(Loan book);
        void Update(Loan book);
        void Delete(Loan book);
        void Save();

        
    }
}
