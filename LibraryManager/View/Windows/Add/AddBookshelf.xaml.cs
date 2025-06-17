using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddBook.xaml
    /// </summary>
    public partial class AddBookshelf : Window
    {
        private readonly IBookshelfRepository _bookshelfRepository;

        public AddBookshelf()
        {
            InitializeComponent();
            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var newBookshelf = new Bookshelf
            {
                Name = nameBox.Text,
                Country = countryBox.Text,
                City = cityBox.Text,
                Street = streetBox.Text,    
                OwnerId = AppUser.User.Id
            };

            await _bookshelfRepository.InsertAsync(newBookshelf);

            MessageBox.Show("Bookshelf added!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }
    }
}
