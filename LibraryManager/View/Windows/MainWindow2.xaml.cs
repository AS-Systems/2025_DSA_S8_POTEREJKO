using LibraryManager.Model.Entities;
using LibraryManager.View.Pages;
using LibraryManager.View.Windows.Info;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        private BooksHolderPage booksHolderPage = new BooksHolderPage();
        private HomePage homePage = new HomePage();
        private BorrowsPage borrowsPage = new BorrowsPage();
        private UsersPage usersPage = new UsersPage();
        private StoragePage storagePage = new StoragePage();
        private User appUser;

        public MainWindow2(User user)
        {
            InitializeComponent();
            appUser = user;

            UserButton.AppUser = appUser;
            
            PageHolder.Content = homePage;

            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");
            MinimiseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "minimise.png");

            HomeBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Home-Light-Icon.png");
            BooksBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Book-Light-Icon.png");
            BorrowsBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Borrows-Light-Icon.png");
            UsersBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Users-Light-Icon.png");
            StorageBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Storage-Light-Icon.png");

            HomeBTN.ButtonClickedImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Home-Dark-Icon.png");
            BooksBTN.ButtonClickedImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Book-Dark-Icon.png");
            BorrowsBTN.ButtonClickedImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Borrows-Dark-Icon.png");
            UsersBTN.ButtonClickedImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Users-Dark-Icon.png");
            StorageBTN.ButtonClickedImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Storage-Dark-Icon.png");



            SetBasicColor();
            HomeBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
            
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimiseBTN_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            await homePage.LoadDataAsync();
            PageHolder.Content = homePage;

            SetBasicColor();
            HomeBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
        }

        private async void BooksBTN_Click(object sender, RoutedEventArgs e)
        {
            await booksHolderPage.LoadDataAsync();
            PageHolder.Content = booksHolderPage;

            SetBasicColor();
            BooksBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
        }

        private void UserButton_ButtonClick(object sender, RoutedEventArgs e)
        {
            new InfoUser(appUser).ShowDialog();
        }

        private async void BorrowsBTN_Click(object sender, RoutedEventArgs e)
        {
            await borrowsPage.LoadDataAsync();
            PageHolder.Content = borrowsPage;

            SetBasicColor();
            BorrowsBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
        }

        private async void UsersBTN_Click(object sender, RoutedEventArgs e)
        {
            await usersPage.LoadDataAsync();
            PageHolder.Content = usersPage;

            SetBasicColor();
            UsersBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
        }

        private async void StorageBTN_Click(object sender, RoutedEventArgs e)
        {
            await storagePage.LoadDataAsync();
            PageHolder.Content = storagePage;

            SetBasicColor();
            StorageBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
        }


        private void SetBasicColor()
        {
            HomeBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            BooksBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            BorrowsBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            UsersBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            StorageBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
        }


    }
}
