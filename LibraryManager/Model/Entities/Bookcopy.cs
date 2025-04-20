using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Bookcopy
{
    public int Id { get; set; }

    public bool IsAvailable { get; set; }

    public int OwnerId { get; set; }

    public int? StorageId { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public virtual User Owner { get; set; } = null!;

    public virtual Storage? Storage { get; set; }
}
