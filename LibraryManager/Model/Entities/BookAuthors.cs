using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class BookAuthors
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int AuthorId { get; set; }

    public virtual Authors Author { get; set; } = null!;

    public virtual Books Book { get; set; } = null!;
}
