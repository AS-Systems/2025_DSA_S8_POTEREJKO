using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Shelf
{
    public int Id { get; set; }

    public int BookshelfId { get; set; }

    public string Name { get; set; } = null!;

    public int AvailableSpace { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public virtual Bookshelf Bookshelf { get; set; } = null!;
}
