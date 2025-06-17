using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Add
{
    /// <summary>
    /// Logika interakcji dla klasy AddShelf.xaml
    /// </summary>
    public partial class AddShelf : Window
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly Bookshelf _bookshelf;


        public AddShelf(Bookshelf bookshelfOwner)
        {
            InitializeComponent();
            _shelfRepository = App.ServiceProvider.GetRequiredService<IShelfRepository>();
            _bookshelf = bookshelfOwner;    
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var shelfToAdd = new Shelf
            {
                Name = nameBox.Text,
                Capacity = int.Parse(capacityBox.Text),
                BookshelfId = _bookshelf.Id,
                AvailableSpace = int.Parse(capacityBox.Text)
            };

            await _shelfRepository.InsertAsync(shelfToAdd);

            MessageBox.Show("Shelf added!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
