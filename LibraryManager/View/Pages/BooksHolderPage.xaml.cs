using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BooksHolderPage.xaml
    /// </summary>
    public partial class BooksHolderPage : Page
    {
        private readonly BooksPage _booksPage = new BooksPage();
        private readonly BookCopiesPage _bookCopiesPage = new BookCopiesPage();

        public BooksHolderPage()
        {
            InitializeComponent();

            SetBasicColor();
            AllBooksBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));

            BooksPageContentPresenter.Content = _booksPage;
        }

        private async void AllBooksBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await _booksPage.LoadDataAsync();
            BooksPageContentPresenter.Content = _booksPage;
           
            SetBasicColor();
            AllBooksBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private async void BookCopiesBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await _bookCopiesPage.LoadDataAsync();
            BooksPageContentPresenter.Content = _bookCopiesPage;

            SetBasicColor();
            BookCopiesBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private void SetBasicColor()
        {
            AllBooksBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
            BookCopiesBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
        }

        public async Task LoadDataAsync()
        {
            await _booksPage.LoadDataAsync();
            await _bookCopiesPage.LoadDataAsync();
        }

    }
}
