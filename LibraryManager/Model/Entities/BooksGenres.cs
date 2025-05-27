using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class BooksGenres
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int GenreId { get; set; }

    public virtual Books Book { get; set; } = null!;

    public virtual Genres Genre { get; set; } = null!;
}
