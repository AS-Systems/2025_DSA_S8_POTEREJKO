using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories
{
    internal class LoanRepository : Interfaces.ILoanRepository
    {
        private readonly LibraryContext _context;
        public LoanRepository(LibraryContext context)
        {
           _context = context; 
        }
        public void Delete(Loan loan)
        {
            var loanToDelete = _context.Loans.Find(loan.Id);
            if (loanToDelete != null)
            {
                _context.Loans.Remove(loanToDelete);
            }
        }

        public IEnumerable<Loan> GetAll()
        {
            var loans = _context.Loans.ToList();
            return loans;
        }

        public Loan GetById(int id)
        {
            var loan = _context.Loans.Find(id);
            return loan;
        }

        public void Insert(Loan loan)
        {
            _context.Loans.Add(loan);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Loan loan)
        {
            var loanToUpdate = _context.Loans.Find(loan.Id);
            if (loanToUpdate != null)
            {
                loanToUpdate.TakeDate = loan.TakeDate;
                loanToUpdate.ReturnDate = loan.ReturnDate;
                loanToUpdate.BookId = loan.BookId;
                loanToUpdate.UserId = loan.UserId;
                _context.SaveChanges();
            }
        }
    }
}
