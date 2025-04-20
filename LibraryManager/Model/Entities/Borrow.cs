using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Borrow
{
    public int Id { get; set; }

    public int BookCopyId { get; set; }

    public int UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Bookcopy BookCopy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
