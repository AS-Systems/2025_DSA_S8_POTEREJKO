using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> BookShelves { get; set; }


        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }


    }
}
