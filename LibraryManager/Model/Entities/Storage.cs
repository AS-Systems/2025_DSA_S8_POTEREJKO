using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Storage
{
    public int Id { get; set; }

    public int ShelfId { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public virtual ICollection<Bookcopy> Bookcopies { get; set; } = new List<Bookcopy>();

    public virtual Shelf Shelf { get; set; } = null!;
}
