using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            var resources = await _bookshelfRepository.GetBookshelfOfUserAsync(AppUser.User.Id); // => for testing only
            //var resources = await _bookshelfRepository.GetBookshelfOfUserAsync(AppUser.User.Id);

            FilteredBookshelves.Clear();
            foreach (var bookshelf in resources)
            {
                FilteredBookshelves.Add(bookshelf);
            }

        }
    }
}
