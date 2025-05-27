using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Shelves
{
    public int Id { get; set; }

    public int BookshelfId { get; set; }

    public string Name { get; set; } = null!;

    public int AvailableSpace { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<BookCopies> BookCopies { get; set; } = new List<BookCopies>();

    public virtual BookShelves Bookshelf { get; set; } = null!;
}
