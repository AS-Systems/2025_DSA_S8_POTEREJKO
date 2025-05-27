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

    public virtual DbSet<Authors> Authors { get; set; }

    public virtual DbSet<BookAuthors> BookAuthors { get; set; }

    public virtual DbSet<BookCopies> BookCopies { get; set; }

    public virtual DbSet<BookShelves> BookShelves { get; set; }

    public virtual DbSet<Books> Books { get; set; }

    public virtual DbSet<BooksGenres> BooksGenres { get; set; }

    public virtual DbSet<Borrows> Borrows { get; set; }

    public virtual DbSet<Genres> Genres { get; set; }

    public virtual DbSet<Shelves> Shelves { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=mysql-home-library-sarass880-book-library.d.aivencloud.com;port=13154;database=HomeLibrary;uid=avnadmin;pwd=AVNS_EkwHAZ05UxBQuiJMdrh;sslmode=Required", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Authors>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Info).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<BookAuthors>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Book_Authors");

            entity.HasIndex(e => e.AuthorId, "fk_author");

            entity.HasIndex(e => e.BookId, "fk_book");

            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("fk_author");

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("fk_book");
        });

        modelBuilder.Entity<BookCopies>(entity =>
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

        modelBuilder.Entity<BookShelves>(entity =>
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

        modelBuilder.Entity<Books>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Cover).HasColumnType("blob");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Iban).HasColumnName("IBAN");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BooksGenres>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Books_Genres");

            entity.HasIndex(e => e.BookId, "fk_book2");

            entity.HasIndex(e => e.GenreId, "fk_genre");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksGenres)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_book2");

            entity.HasOne(d => d.Genre).WithMany(p => p.BooksGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_genre");
        });

        modelBuilder.Entity<Borrows>(entity =>
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

        modelBuilder.Entity<Genres>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Shelves>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.BookshelfId, "fh_Bookshelf");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Bookshelf).WithMany(p => p.Shelves)
                .HasForeignKey(d => d.BookshelfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bookshelf");
        });

        modelBuilder.Entity<Users>(entity =>
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
