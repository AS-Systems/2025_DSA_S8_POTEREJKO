using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Window
    {
        private readonly IAuthorRepository _authorRepository;

        public AddAuthor()
        {
            InitializeComponent();
            _authorRepository = App.ServiceProvider.GetRequiredService<IAuthorRepository>();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var newAuthor = new Author
            {
                Name = nameBox.Text,
                Surname = surnameBox.Text,
                Info = infoBox.Text
            };
        
           _authorRepository.InsertAsync(newAuthor);
        }
    }
}
