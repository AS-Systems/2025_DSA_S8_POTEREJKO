using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.View.Windows;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BookCopiesPage.xaml
    /// </summary>
    public partial class BookCopiesPage : Page, INotifyPropertyChanged
    {
        private readonly IBookCopyRepository _bookCopyRepository;


        public ObservableCollection<BookCopy> BookCopies { get; set; } = new ObservableCollection<BookCopy>();

        private Book selectedBookCopy;

        public Book SelectedBookCopy
        {
            get { return selectedBookCopy; }
            set
            {
                selectedBookCopy = value;
                OnPropertyChanged();
            }
        }

        public BookCopiesPage()
        {
            InitializeComponent();
            _bookCopyRepository = App.ServiceProvider.GetRequiredService<IBookCopyRepository>();


            DataContext = this;
        }

        public async Task LoadDataAsync()
        {
            var bookCopies = await _bookCopyRepository.GetAllBookCopiesOfUserAsync(AppUser.User.Id);

            BookCopies.Clear();
            foreach (var bookCopy in bookCopies)
            { 
                BookCopies.Add(bookCopy);
            }

        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void CircularSingleButtonControl_ButtonSubClick(object sender, RoutedEventArgs e)
        {
            var window = new AddBookCopy();
            window.Owner = Window.GetWindow(this);  
            await window.LoadDataAsync();

            var result = window.ShowDialog();

            if (result == true)
            {
                await LoadDataAsync();
            }

        }

        private async void BookCopyItemTemplate_Deleted(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
