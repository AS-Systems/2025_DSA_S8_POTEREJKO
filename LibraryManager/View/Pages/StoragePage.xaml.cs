using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using LibraryManager.View.Windows.Add;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        private readonly IBookshelfRepository _bookshelfRepository;
        public ObservableCollection<Bookshelf> FilteredBookshelves { get; set; } = new ObservableCollection<Bookshelf>();
        public StoragePage()
        {
            InitializeComponent();            
            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();  

            DataContext = this;
        }

        public async Task LoadDataAsync()
        {
            var resources = await _bookshelfRepository.GetBookshelfOfUserAsync(AppUser.User.Id);

            FilteredBookshelves.Clear();
            foreach (var bookshelf in resources)
            {
                FilteredBookshelves.Add(bookshelf);
            }

        }

        private async void BookshelfItemTemplate_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private async void CircularDoubleButtonControl_ButtonTopClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new AddBookshelf();
            window.Owner = Window.GetWindow(this);

            var result = window.ShowDialog();

            await LoadDataAsync();
            
        }

        private async void CircularDoubleButtonControl_ButtonBottomClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new AddShelfCombo();
            window.Owner = Window.GetWindow(this);
            await window.LoadDataAsync();

            var result = window.ShowDialog();

            if (result == true) 
            {
                await LoadDataAsync();
            }
        }
    }
}
