using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowsPageReturns.xaml
    /// </summary>
    public partial class BorrowsPageReturns : Page
    {
        public List<Borrow> ReturnsList { get; set; }


        public BorrowsPageReturns()
        {
            InitializeComponent();
            DataContext = this;

            var borrowList = new List<Borrow>
            {
            new Borrow
            {
                Id = 1,
                BookCopyId = 101,
                UserId = 1001,
                BorrowDate = DateTime.Now.AddHours(-7),
                ReturnDate = DateTime.Now.AddHours(4),
                BookCopy = new BookCopy { Id = 101, BookId = 201, Book = new Book{ Title = "Title 1"} },
                User = new User { Id = 1001, Name = "Jan Kowalski", Email = "jan.kowalski@example.com" }
            },
            new Borrow
            {
                Id = 2,
                BookCopyId = 102,
                UserId = 1002,
                BorrowDate = DateTime.Now.AddHours(-2),
                ReturnDate = DateTime.Now.AddHours(2),
                BookCopy = new BookCopy { Id = 102, BookId = 202, Book = new Book{ Title = "Title 2"} },
                User = new User { Id = 1002, Name = "Anna Nowak", Email = "anna.nowak@example.com" }
            },
            new Borrow
            {
                Id = 3,
                BookCopyId = 103,
                UserId = 1003,
                BorrowDate = DateTime.Now.AddHours(-5),
                ReturnDate = DateTime.Now.AddHours(3),
                BookCopy = new BookCopy { Id = 103, BookId = 203, Book = new Book{ Title = "Title 3"} },
                User = new User { Id = 1003, Name = "Piotr Wiśniewski", Email = "piotr.wisniewski@example.com" }
            }
            };

            ReturnsList = borrowList;
        }
    }
}
