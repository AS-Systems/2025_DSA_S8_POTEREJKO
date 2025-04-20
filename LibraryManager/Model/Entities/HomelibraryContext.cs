using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Entities;

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

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Bookcopy> Bookcopies { get; set; }

    public virtual DbSet<Bookshelf> Bookshelves { get; set; }

    public virtual DbSet<Borrow> Borrows { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseMySql("server=192.168.0.207;database=homelibrary;user id=test;password=twoje_haslo;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("authors");

            entity.Property(e => e.Info).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.AuthorId, "AuthorId");

            entity.Property(e => e.Cover).HasColumnType("blob");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_ibfk_1");
        });

        modelBuilder.Entity<Bookcopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bookcopies");

            entity.HasIndex(e => e.BookId, "BookId");

            entity.HasIndex(e => e.OwnerId, "OwnerId");

            entity.HasIndex(e => e.StorageId, "StorageId");

            entity.HasOne(d => d.Book).WithMany(p => p.Bookcopies)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("bookcopies_ibfk_3");

            entity.HasOne(d => d.Owner).WithMany(p => p.Bookcopies)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("bookcopies_ibfk_1");

            entity.HasOne(d => d.Storage).WithMany(p => p.Bookcopies)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("bookcopies_ibfk_2");
        });

        modelBuilder.Entity<Bookshelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bookshelves");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("borrows");

            entity.HasIndex(e => e.BookCopyId, "BookCopyId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.BorrowDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.BookCopy).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BookCopyId)
                .HasConstraintName("borrows_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("borrows_ibfk_2");
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shelves");

            entity.HasIndex(e => e.BookShelfeId, "BookShelfeId");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.BookShelfe).WithMany(p => p.Shelves)
                .HasForeignKey(d => d.BookShelfeId)
                .HasConstraintName("shelves_ibfk_1");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("storages");

            entity.HasIndex(e => e.ShelfId, "ShelfId");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(255);

            entity.HasOne(d => d.Shelf).WithMany(p => p.Storages)
                .HasForeignKey(d => d.ShelfId)
                .HasConstraintName("storages_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

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
