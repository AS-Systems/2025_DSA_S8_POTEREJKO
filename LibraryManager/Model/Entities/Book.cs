using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Book
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int OwnerId { get; set; }

    public string Title { get; set; } = null!;

    public int Genre { get; set; }

    public int PageCount { get; set; }

    public bool? IsAvailable { get; set; }

    public string? Description { get; set; }

    public int StorageId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual User Owner { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;
}
