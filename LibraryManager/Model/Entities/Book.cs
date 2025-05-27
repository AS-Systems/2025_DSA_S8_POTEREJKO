using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte[]? Cover { get; set; }

    public int? PageCount { get; set; }

    public string? Description { get; set; }

    public int Iban { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public virtual ICollection<BooksGenre> BooksGenres { get; set; } = new List<BooksGenre>();
}
