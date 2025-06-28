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
using System.Windows.Input;
using LibraryManager.Services;

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

        private void Bookshelf_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the bookshelf.");
        }

        private void Shelf_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Number of shelves in the bookshelf.");
        }

        private void Storage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Available storage in the bookshelf.");
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can add a new bookshelf or shelf.");
        }

        private void Field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can hover over the fields to get more information.");
        }

    }
}
