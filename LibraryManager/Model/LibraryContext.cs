using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> BookShelves { get; set; }

        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Borrower>("Borrower")
                .HasValue<Author>("Author");

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Storage)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.StorageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Borrows)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Borrow>()
                .HasOne(l => l.Borrower)
                .WithMany(u => u.Borrows)
                .HasForeignKey(l => l.BorrowerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Storage>()
                .HasOne(s => s.Shelf)
                .WithMany(s => s.Storages)
                .HasForeignKey(s => s.ShelfId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Storage>()
                .HasOne(s => s.BookShelf)
                .WithMany(b => b.Storages)
                .HasForeignKey(s => s.BookShelfId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.BookShelf)
                .WithMany(b => b.Shelves)
                .HasForeignKey(s => s.BookShelfId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
