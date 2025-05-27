using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BooksGenre> BooksGenres { get; set; } = new List<BooksGenre>();
}
