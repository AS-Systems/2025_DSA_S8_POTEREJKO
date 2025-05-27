using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class BookCopies
{
    public int Id { get; set; }

    public int ShelfId { get; set; }

    public int OwnerId { get; set; }

    public int BookId { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Books Book { get; set; } = null!;

    public virtual ICollection<Borrows> Borrows { get; set; } = new List<Borrows>();

    public virtual Users Owner { get; set; } = null!;

    public virtual Shelves Shelf { get; set; } = null!;
}
