using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Bookshelf
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public bool HasSpace { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
}
