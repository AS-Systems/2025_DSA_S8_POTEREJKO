using System;
using System.Collections.Generic;
using LibraryManager.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model;

public partial class HomelibraryContext : DbContext
{
    public HomelibraryContext()
    {
    }

    public HomelibraryContext(DbContextOptions<HomelibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    public virtual DbSet<Bookshelf> BookShelves { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksGenre> BooksGenres { get; set; }

    public virtual DbSet<Borrow> Borrows { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=mysql-home-library-sarass880-book-library.d.aivencloud.com;port=13154;database=HomeLibrary;uid=avnadmin;pwd=AVNS_EkwHAZ05UxBQuiJMdrh;sslmode=Required", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Info).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("Book_Authors");

            entity.HasKey(e => new { e.BookId, e.AuthorId }).HasName("PRIMARY");

            entity.HasIndex(e => e.AuthorId, "fk_author");

            entity.HasIndex(e => e.BookId, "fk_book");

            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("fk_author");

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("fk_book");
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.BookId, "fk_book3");

            entity.HasIndex(e => e.OwnerId, "fk_owner");

            entity.HasIndex(e => e.ShelfId, "fk_shelf");

            entity.HasOne(d => d.Book).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_book3");

            entity.HasOne(d => d.Owner).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner");

            entity.HasOne(d => d.Shelf).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.ShelfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_shelf");
        });

        modelBuilder.Entity<Bookshelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.OwnerId, "fk_owner2");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Street).HasMaxLength(255);

            entity.HasOne(d => d.Owner).WithMany(p => p.BookShelves)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_owner2");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Cover).HasColumnType("blob");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Iban).HasColumnName("IBAN");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BooksGenre>(entity =>
        {
            entity.ToTable("Books_Genres");

            entity.HasKey(e => new { e.BookId, e.GenreId }).HasName("PRIMARY");

            entity.HasIndex(e => e.BookId).HasDatabaseName("fk_book2");

            entity.HasIndex(e => e.GenreId).HasDatabaseName("fk_genre");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksGenres)
                    .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_book2");

            entity.HasOne(d => d.Genre).WithMany(p => p.BooksGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_genre");
        });

        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.BookCopyId, "fk_bookcopy");

            entity.HasIndex(e => e.UserId, "fk_user");

            entity.Property(e => e.BorrowDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.BookCopy).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BookCopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bookcopy");

            entity.HasOne(d => d.User).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.BookshelfId, "fh_Bookshelf");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Bookshelf).WithMany(p => p.Shelves)
                .HasForeignKey(d => d.BookshelfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bookshelf");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfilePicture).HasColumnType("blob");
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
