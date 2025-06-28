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
using LibraryManager.Services;
using System.Windows.Input;

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

        private async void BorrowsCurrentBtn_Click(object sender, RoutedEventArgs e)
        {
            await _pageCurrent.LoadDataAsync();
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

        private async void CheckOutsBtn_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageCheckouts;
            await _pageCheckouts.LoadDataAsync();

            SetBasicColor();
            CheckOutsBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bec29b"));
        }

        private async void ReturnsButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowsPageContentPresenter.Content = _pageReturns;
            await _pageReturns.LoadDataAsync();

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

        private void BorrowsFinished_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to view finished borrows.");
        }

        private void Current_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to view current borrows.");
        }

        private void Upcomming_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to view upcoming borrows.");
        }

        private void CheckOuts_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to view checkouts.");
        }

        private void Returns_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to view returns.");
        }

        private void Field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Hover over an element to see more information.");
        }
    }
}
