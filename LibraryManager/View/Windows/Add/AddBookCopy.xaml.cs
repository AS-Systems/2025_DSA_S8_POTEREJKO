using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddBook.xaml
    /// </summary>
    public partial class AddBookCopy : Window
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IBookshelfRepository _bookshelfRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IBookRepository _bookRepository;


        public AddBookCopy()
        {
            InitializeComponent();

            _bookCopyRepository = App.ServiceProvider.GetRequiredService<IBookCopyRepository>();
            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();
            _shelfRepository = App.ServiceProvider.GetRequiredService<IShelfRepository>();
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void bookShelfBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedBookshelf = comboBox?.SelectedItem as Bookshelf;

            if (selectedBookshelf is not null )
            {
                var shelves = await _shelfRepository.GetAllShelvesOfBookshelfAsync(selectedBookshelf.Id);
                shelfBox.ItemsSource = shelves;
                shelfBox.SelectedItem = null;
            }

        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var book = bookBox.SelectedItem as Book;
            var shelf = shelfBox.SelectedItem as Shelf;
            var available = availableBox.IsChecked;

            if (book is not null && shelf is not null && available is not null)
            {
                var newBookCopy = new BookCopy
                {
                    Book = book,
                    OwnerId = AppUser.User.Id
                };

                if (shelf.AvailableSpace > 0)
                {
                    newBookCopy.Shelf = shelf;

                }
                else 
                {
                    MessageBox.Show("Selected shelf has no free space!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                if (available == true)
                {
                    newBookCopy.IsAvailable = true;
                }
                else
                {
                    newBookCopy.IsAvailable = false;
                }

                await _bookCopyRepository.AddBookCopyAsync(newBookCopy);

                shelf.AvailableSpace -= 1;
                await _shelfRepository.UpdateAsync(shelf);

                MessageBox.Show("Item added!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
            }
            else
            {
                await Task.CompletedTask;
                DialogResult = false;
            }

        }

        public async Task LoadDataAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var bookShelfs = await _bookshelfRepository.GetBookshelfOfUserAsync(AppUser.User.Id);

            bookBox.ItemsSource = books;
            bookShelfBox.ItemsSource = bookShelfs;

        }

    }
}
