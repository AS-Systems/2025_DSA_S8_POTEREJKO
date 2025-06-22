using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Edit
{
    /// <summary>
    /// Logika interakcji dla klasy InfoBook.xaml
    /// </summary>
    public partial class EditBookCopy : Window
    {
        private readonly IBookCopyRepository _bookCopyRepository;  
        private readonly IBookshelfRepository _bookshelfRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IBookRepository _bookRepository;

        private BookCopy _bookCopy;

        public EditBookCopy(BookCopy bookCopy)
        {
            InitializeComponent();
            _bookCopy = bookCopy;   


            _bookCopyRepository = App.ServiceProvider.GetRequiredService<IBookCopyRepository>();
            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();
            _shelfRepository = App.ServiceProvider.GetRequiredService<IShelfRepository>();
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();

            availableBox.IsChecked = _bookCopy.IsAvailable;
            
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var newBook = bookBox.SelectedItem as Book;
            if (newBook is not null)
            { 
                _bookCopy.Book = newBook;
            }


            var newShelf = shelfBox.SelectedItem as Shelf;
            if (newShelf is not null)
            {
                _bookCopy.Shelf = newShelf;
            }

            if (availableBox.IsChecked == true)
            {
                _bookCopy.IsAvailable = true;
            }
            else 
            {
                _bookCopy.IsAvailable = false;
            }   

            await _bookCopyRepository.UpdateBookCopyAsync(_bookCopy);
            MessageBox.Show("Item updated!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }

        public async Task LoadDataAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var bookShelfs = await _bookshelfRepository.GetBookshelfOfUserAsync(AppUser.User.Id);
            var shelves = await _shelfRepository.GetAllShelvesOfBookshelfAsync(_bookCopy.ShelfId);


            bookBox.ItemsSource = books;
            bookBox.SelectedItem =  _bookCopy.Book;

            bookShelfBox.ItemsSource = bookShelfs;
            bookShelfBox.SelectedItem = _bookCopy.Shelf.Bookshelf;

            shelfBox.ItemsSource = shelves;
            shelfBox.SelectedItem = _bookCopy.Shelf;


        }

        private async void bookShelfBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedBookshelf = comboBox?.SelectedItem as Bookshelf;

            if (selectedBookshelf is not null && selectedBookshelf != _bookCopy.Shelf.Bookshelf)
            {
                var shelves = await _shelfRepository.GetAllShelvesOfBookshelfAsync(selectedBookshelf.Id);
                shelfBox.ItemsSource = shelves;
                shelfBox.SelectedItem = null;
            }
            else if (selectedBookshelf == _bookCopy.Shelf.Bookshelf)
            {
                var shelves = await _shelfRepository.GetAllShelvesOfBookshelfAsync(selectedBookshelf.Id);
                shelfBox.ItemsSource = shelves;
                shelfBox.SelectedItem = _bookCopy.Shelf;
            }

        }
    }
}
