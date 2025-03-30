using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Bookshelf
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool HasSpace { get; set; }

    public virtual ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
}
