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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowsPage.xaml
    /// </summary>
    public partial class BorrowsPage : Page
    {
        private readonly BorrowsPageFinished _pageFinished = new BorrowsPageFinished();
        private readonly BorrowsPageCurrent _pageCurrent = new BorrowsPageCurrent();
        private readonly BorrowsPageUpcoming _pageUpcoming = new BorrowsPageUpcoming();

        public BorrowsPage()
        {
            InitializeComponent();

            BorrowsPageContentPresenter.Content = _pageFinished;

        }

        private void BorrowsFinishedBtn_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageFinished;
        }

        private void BorrowsCurrentBtn_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageCurrent;
        }

        private void BorrowsUpcommingBtn_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageUpcoming;
        }
    }
}
