using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public ObservableCollection<Book> Books { get; set; }

        public BooksPage()
        {
            InitializeComponent();

            Books = new ObservableCollection<Book>
{
    new Book
    {
        Id = 1,
        Title = "The Fellowship of the Ring",
        AuthorId = 101,
        Author = new Author { Id = 101, Name = "J.R.R. Tolkien" },
        OwnerId = 201,
        Owner = new User { Id = 201, Username = "LibraryAdmin" },
        Genre = 1,
        PageCount = 423,
        IsAvailable = true,
        Description = "The first part of the epic Lord of the Rings trilogy.",
        StorageId = 301,
        Storage = new Storage (),
        Borrows = new List<Borrow>()
    },
    new Book
    {
        Id = 2,
        Title = "1984",
        AuthorId = 102,
        Author = new Author { Id = 102, Name = "George Orwell" },
        OwnerId = 202,
        Owner = new User { Id = 202, Username = "LibrarianJoe" },
        Genre = 2,
        PageCount = 328,
        IsAvailable = false,
        Description = "A dystopian novel about totalitarianism and surveillance.",
        StorageId = 302,
        Storage = new Storage(),
        Borrows = new List<Borrow>()
    },
    new Book
    {
        Id = 3,
        Title = "Pride and Prejudice",
        AuthorId = 103,
        Author = new Author { Id = 103, Name = "Jane Austen" },
        OwnerId = 203,
        Owner = new User { Id = 203, Username = "ClassicLover" },
        Genre = 3,
        PageCount = 279,
        IsAvailable = true,
        Description = "A romantic novel of manners in 19th-century England.",
        StorageId = 303,
        Storage = new Storage(),
        Borrows = new List<Borrow>()
    },
    new Book
    {
        Id = 4,
        Title = "To Kill a Mockingbird",
        AuthorId = 104,
        Author = new Author { Id = 104, Name = "Harper Lee" },
        OwnerId = 204,
        Owner = new User { Id = 204, Username = "Read4Justice" },
        Genre = 4,
        PageCount = 336,
        IsAvailable = true,
        Description = "A novel about racial injustice in the Deep South.",
        StorageId = 304,
        Storage = new Storage(),
        Borrows = new List<Borrow>()
    },
    new Book
    {
        Id = 5,
        Title = "Dune",
        AuthorId = 105,
        Author = new Author { Id = 105, Name = "Frank Herbert" },
        OwnerId = 205,
        Owner = new User { Id = 205, Username = "SciFiFan" },
        Genre = 5,
        PageCount = 688,
        IsAvailable = false,
        Description = "A science fiction epic set on the desert planet Arrakis.",
        StorageId = 305,
        Storage = new Storage(),
        Borrows = new List<Borrow>()
    }
};


            DataContext = this;

        }
    }


}
