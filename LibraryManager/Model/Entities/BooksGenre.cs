using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class BooksGenre
{

    public int BookId { get; set; }

    public int GenreId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
