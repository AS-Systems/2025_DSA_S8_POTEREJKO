using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte[]? Cover { get; set; }

    public int? Genre { get; set; }

    public int? PageCount { get; set; }

    public string? Description { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Bookcopy> Bookcopies { get; set; } = new List<Bookcopy>();
}
