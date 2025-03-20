using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;

namespace LibraryManager.Model.Repositories
{
    internal class UserRepository : Interfaces.IUserRepository
    {
        private readonly LibraryContext _context;
        public UserRepository(LibraryContext context)
        {
           _context = context; 
        }
        public void Delete(User user)
        {
            var userToDelete = _context.Users.Find(user.Id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var userToUpdate = _context.Users.Find(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Phone = user.Phone;
                userToUpdate.Name = user.Name;
                userToUpdate.Surname = user.Surname;
                _context.SaveChanges();
            }
        }
    }
}
