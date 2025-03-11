using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> BookShelves { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<User>("User")
                .HasValue<Author>("Author");

            //Book info
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Storage)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.StorageId);

            //Loan info
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId);

            //Storage info
            modelBuilder.Entity<Storage>()
                .HasOne(s => s.Shelf)
                .WithMany(s => s.Storages)
                .HasForeignKey(s => s.ShelfId);
            modelBuilder.Entity<Storage>()
                .HasOne(s => s.BookShelf)
                .WithMany(b => b.Storages)
                .HasForeignKey(s => s.BookShelfId);

            //Shelf info
            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.BookShelf)
                .WithMany(b => b.Shelfs)
                .HasForeignKey(s => s.BookShelfId);
        }


    }
}
