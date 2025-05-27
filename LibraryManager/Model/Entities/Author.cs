using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Info { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}
