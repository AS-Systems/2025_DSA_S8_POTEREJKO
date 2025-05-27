using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class User
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

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public virtual ICollection<Bookshelf> BookShelves { get; set; } = new List<Bookshelf>();

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}
