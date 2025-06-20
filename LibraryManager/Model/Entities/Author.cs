using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Model.Entities;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Info { get; set; }
    public byte[]? AuthorPicture { get; set; }


    [NotMapped]
    public string DisplayName => Name + " " + Surname;

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}
