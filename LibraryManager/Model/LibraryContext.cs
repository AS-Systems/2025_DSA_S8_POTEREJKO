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
                .HasValue<User>("User")
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

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId)
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

            //seed data
            modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Author1", Surname = "Surname1" },
            new Author { Id = 2, Name = "Author2", Surname = "Surname2" },
            new Author { Id = 3, Name = "Author3", Surname = "Surname3" },
            new Author { Id = 4, Name = "Author4", Surname = "Surname4" },
            new Author { Id = 5, Name = "Author5", Surname = "Surname5" },
            new Author { Id = 6, Name = "Author6", Surname = "Surname6" },
            new Author { Id = 7, Name = "Author7", Surname = "Surname7" },
            new Author { Id = 8, Name = "Author8", Surname = "Surname8" },
            new Author { Id = 9, Name = "Author9", Surname = "Surname9" },
            new Author { Id = 10, Name = "Author10", Surname = "Surname10" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User", Surname = "Surname", Phone = "1234567890" },
                new User { Id = 2, Name = "User2", Surname = "Surname2", Phone = "0987654321" },
                new User { Id = 3, Name = "User3", Surname = "Surname3", Phone = "1234567890" },
                new User { Id = 4, Name = "User4", Surname = "Surname4", Phone = "0987654321" },
                new User { Id = 5, Name = "User5", Surname = "Surname5", Phone = "1234567890" },
                new User { Id = 6, Name = "User6", Surname = "Surname6", Phone = "0987654321" },
                new User { Id = 7, Name = "User7", Surname = "Surname7", Phone = "1234567890" },
                new User { Id = 8, Name = "User8", Surname = "Surname8", Phone = "0987654321" },
                new User { Id = 9, Name = "User9", Surname = "Surname9", Phone = "1234567890" },
                new User { Id = 10, Name = "User10", Surname = "Surname10", Phone = "0987654321" }
            );

            modelBuilder.Entity<Shelf>().HasData(
                new Shelf { Id = 1, Number = 1, BookShelfId = 1 },
                new Shelf { Id = 2, Number = 2, BookShelfId = 1 },
                new Shelf { Id = 3, Number = 3, BookShelfId = 1 },
                new Shelf { Id = 4, Number = 4, BookShelfId = 1 },
                new Shelf { Id = 5, Number = 5, BookShelfId = 1 },
                new Shelf { Id = 6, Number = 6, BookShelfId = 1 },
                new Shelf { Id = 7, Number = 7, BookShelfId = 1 },
                new Shelf { Id = 8, Number = 8, BookShelfId = 1 },
                new Shelf { Id = 9, Number = 9, BookShelfId = 1 },
                new Shelf { Id = 10, Number = 10, BookShelfId = 1 }
            );

            modelBuilder.Entity<Storage>().HasData(
                new Storage { Id = 1, ShelfId = 1, BookShelfId = 1 },
                new Storage { Id = 2, ShelfId = 2, BookShelfId = 1 },
                new Storage { Id = 3, ShelfId = 3, BookShelfId = 1 },
                new Storage { Id = 4, ShelfId = 4, BookShelfId = 1 },
                new Storage { Id = 5, ShelfId = 5, BookShelfId = 1 },
                new Storage { Id = 6, ShelfId = 6, BookShelfId = 1 },
                new Storage { Id = 7, ShelfId = 7, BookShelfId = 1 },
                new Storage { Id = 8, ShelfId = 8, BookShelfId = 1 },
                new Storage { Id = 9, ShelfId = 9, BookShelfId = 1 },
                new Storage { Id = 10, ShelfId = 10, BookShelfId = 1 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book1", Genre = Genre.Fantasy, PageCount = 300, AuthorId = 1, StorageId = 1 },
                new Book { Id = 2, Title = "Book2", Genre = Genre.Action, PageCount = 200, AuthorId = 2, StorageId = 2 },
                new Book { Id = 3, Title = "Book3", Genre = Genre.Horror, PageCount = 150, AuthorId = 3, StorageId = 3 },
                new Book { Id = 4, Title = "Book4", Genre = Genre.Fantasy, PageCount = 400, AuthorId = 4, StorageId = 4 },
                new Book { Id = 5, Title = "Book5", Genre = Genre.Action, PageCount = 250, AuthorId = 5, StorageId = 5 },
                new Book { Id = 6, Title = "Book6", Genre = Genre.Horror, PageCount = 350, AuthorId = 6, StorageId = 6 },
                new Book { Id = 7, Title = "Book7", Genre = Genre.Fantasy, PageCount = 500, AuthorId = 7, StorageId = 7 },
                new Book { Id = 8, Title = "Book8", Genre = Genre.Action, PageCount = 300, AuthorId = 8, StorageId = 8 },
                new Book { Id = 9, Title = "Book9", Genre = Genre.Horror, PageCount = 200, AuthorId = 9, StorageId = 9 },
                new Book { Id = 10, Title = "Book10", Genre = Genre.Fantasy, PageCount = 450, AuthorId = 10, StorageId = 10 }
            );
        }

    }
}
