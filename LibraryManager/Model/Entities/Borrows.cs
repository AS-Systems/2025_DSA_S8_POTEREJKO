using System;
using System.Collections.Generic;

namespace LibraryManager.Model.Entities;

public partial class Borrows
{
    public int Id { get; set; }

    public int BookCopyId { get; set; }

    public int UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual BookCopies BookCopy { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
