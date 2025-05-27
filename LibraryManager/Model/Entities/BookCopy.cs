using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class BookCopy
{
    public int Id { get; set; }

    public int ShelfId { get; set; }

    public int OwnerId { get; set; }

    public int BookId { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual User Owner { get; set; } = null!;

    public virtual Shelf Shelf { get; set; } = null!;
}
