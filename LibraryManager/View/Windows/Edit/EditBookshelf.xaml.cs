using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows.Add;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddBook.xaml
    /// </summary>
    public partial class EditBookshelf : Window, INotifyPropertyChanged
    {

        private readonly IShelfRepository _shelfRepository;
        private readonly IBookshelfRepository _bookshelfRepository;
        private Bookshelf editedBookshelf;


        public ObservableCollection<Shelf> Shelves { get; set; } = new ObservableCollection<Shelf>();
        private Shelf selectedShelf;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Shelf SelectedShelf
        {
            get { return selectedShelf; }
            set
            {
                selectedShelf = value;
                OnPropertyChanged();
            }
        }

        public EditBookshelf(Bookshelf bookshelf)
        {
            InitializeComponent();
            DataContext = this;

            editedBookshelf = bookshelf;
            _shelfRepository = App.ServiceProvider.GetRequiredService<IShelfRepository>();
            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();  

            deleteButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "delete.png");
            addButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "add.png");

            nameBox.Text = bookshelf.Name;
            cityBox.Text = bookshelf.City;
            countryBox.Text = bookshelf.Country;
            streetBox.Text = bookshelf.Street;

            Shelves.Clear();
            foreach (var shelf in bookshelf.Shelves)
            {
                Shelves.Add(shelf);
            }

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ImageDropControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void addButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            var window = new AddShelf(editedBookshelf);
            window.Owner = this;

            var result = window.ShowDialog();

            if (result == true)
            {
                await LoadDataAsync();
            }
        }

        private async void deleteButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (selectedShelf is not null)
            {
                var answer = MessageBox.Show($"Are you sure you want to pernamently delete the shelf: {selectedShelf.Name} with id: {selectedShelf.Id}", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (answer == MessageBoxResult.Yes)
                {
                    await _shelfRepository.DeleteAsync(selectedShelf);
                    await LoadDataAsync();
                }
            }
        }


        public async Task LoadDataAsync()
        {
            var shelves = await _shelfRepository.GetAllShelvesOfBookshelfAsync(editedBookshelf.Id);

            Shelves.Clear();
            foreach (var shelf in shelves)
            {
                Shelves.Add(shelf);
            }
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var shelves =  await _shelfRepository.GetAllShelvesOfBookshelfAsync(editedBookshelf.Id);

            editedBookshelf.Name = nameBox.Text;
            editedBookshelf.Country = countryBox.Text;
            editedBookshelf.City = cityBox.Text;
            editedBookshelf.Street = streetBox.Text;

            editedBookshelf.Shelves = shelves.ToList();


            await _bookshelfRepository.UpdateAsync(editedBookshelf);

            MessageBox.Show("Changes saved!", "Info",MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }
    }
}
