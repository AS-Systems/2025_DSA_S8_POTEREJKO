using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BookCopiesPage.xaml
    /// </summary>
    public partial class BookCopiesPage : Page
    {
        public BookCopiesPage()
        {
            InitializeComponent();
        }

        public async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }
    }
}
