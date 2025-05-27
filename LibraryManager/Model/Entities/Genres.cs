using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Genres
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BooksGenres> BooksGenres { get; set; } = new List<BooksGenres>();
}
