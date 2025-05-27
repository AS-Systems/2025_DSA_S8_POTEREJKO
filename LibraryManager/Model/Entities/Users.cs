using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Users
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public sbyte Role { get; set; }

    public virtual ICollection<BookCopies> BookCopies { get; set; } = new List<BookCopies>();

    public virtual ICollection<BookShelves> BookShelves { get; set; } = new List<BookShelves>();

    public virtual ICollection<Borrows> Borrows { get; set; } = new List<Borrows>();
}
