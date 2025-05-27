using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Books
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte[]? Cover { get; set; }

    public int? PageCount { get; set; }

    public string? Description { get; set; }

    public int Iban { get; set; }

    public virtual ICollection<BookAuthors> BookAuthors { get; set; } = new List<BookAuthors>();

    public virtual ICollection<BookCopies> BookCopies { get; set; } = new List<BookCopies>();

    public virtual ICollection<BooksGenres> BooksGenres { get; set; } = new List<BooksGenres>();
}
