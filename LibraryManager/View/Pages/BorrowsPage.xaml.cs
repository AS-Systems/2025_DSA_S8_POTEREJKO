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
        private readonly BorrowsPageReturns _pageReturns = new BorrowsPageReturns();
        private readonly BorrowsPageCheckOuts _pageCheckouts = new BorrowsPageCheckOuts();

        public BorrowsPage()
        {
            InitializeComponent();


            BorrowsPageContentPresenter.Content = _pageFinished;

            SetBasicColor();
            BorrowsFinishedBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private async void BorrowsFinishedBtn_Click(object sender, RoutedEventArgs e)
        {
            await _pageFinished.LoadDataAsync();
            BorrowsPageContentPresenter.Content = _pageFinished;

            SetBasicColor();
            BorrowsFinishedBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private void BorrowsCurrentBtn_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageCurrent;

            SetBasicColor();
            BorrowsCurrentBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private async void BorrowsUpcommingBtn_Click(object sender, RoutedEventArgs e)
        {
            await _pageUpcoming.LoadDataAsync();
            BorrowsPageContentPresenter.Content = _pageUpcoming;

            SetBasicColor();
            BorrowsUpcommingBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private void CheckOutsBtn_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageCheckouts;

            SetBasicColor();
            CheckOutsBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private void ReturnsButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageReturns;

            SetBasicColor();
            ReturnsButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }


        private void SetBasicColor()
        {
            BorrowsFinishedBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
            BorrowsCurrentBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
            BorrowsUpcommingBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
            CheckOutsBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
            ReturnsButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"));
        }


        public async Task LoadDataAsync()
        {
            await _pageFinished.LoadDataAsync();
        }


    }
}
