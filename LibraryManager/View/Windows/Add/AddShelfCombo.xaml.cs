using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManager.View.Windows.Add
{
    /// <summary>
    /// Logika interakcji dla klasy AddShelfCombo.xaml
    /// </summary>
    public partial class AddShelfCombo : Window
    {
        private readonly IBookshelfRepository _bookshelfRepository;
        private readonly IShelfRepository _shelfRepository;

        public AddShelfCombo()
        {
            InitializeComponent();
            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();
            _shelfRepository = App.ServiceProvider.GetRequiredService<IShelfRepository>();
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Shelf newShelf;

            if (bookshelfCombo.SelectedItem is not null)
            {
                var selectedBookshelf = bookshelfCombo.SelectedItem as Bookshelf;

                if (selectedBookshelf is not null)
                {
                    newShelf = new Shelf
                    {
                        Name = nameBox.Text,
                        Capacity = int.Parse(capacityBox.Text),
                        AvailableSpace = int.Parse(capacityBox.Text),
                        BookshelfId = selectedBookshelf.Id
                    };
                    await _shelfRepository.InsertAsync(newShelf);

                    MessageBox.Show("Shelf added!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            DialogResult = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public async Task LoadDataAsync()
        {
            var bookshelfs = await _bookshelfRepository.GetBookshelfOfUserAsync(AppUser.User.Id);

            bookshelfCombo.ItemsSource = bookshelfs;

            if (bookshelfs.Count() > 0) 
            {
                bookshelfCombo.SelectedItem = bookshelfs.ToList()[0];
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
