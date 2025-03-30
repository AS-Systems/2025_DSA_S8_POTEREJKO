using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Shelf
{
    public int Id { get; set; }

    public int BookShelfeId { get; set; }

    public string Name { get; set; } = null!;

    public int AvaliableSpace { get; set; }

    public int Capacity { get; set; }

    public virtual Bookshelf BookShelfe { get; set; } = null!;

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();
}
