using LibraryManager.Model.Entities;
using LibraryManager.Services;
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
        private HomePage homePage;
        private BorrowsPage borrowsPage = new BorrowsPage();
        private UsersPage usersPage = new UsersPage();
        private StoragePage storagePage = new StoragePage();
        private User appUser;
        private String messageForClippy;

        public MainWindow2(User user)
        {
            InitializeComponent();
            appUser = user;
            homePage = new HomePage(appUser);

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
            
            this.PreviewKeyDown += OnKeyDown;
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                ClippyService.ToggleVisibility();
                if (ClippyService.IsVisible)
                    SayPageSpecificClippyMessage(); 
            }
        }

        private void Field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                SayPageSpecificClippyMessage(); 
        }

        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Here you can see the home page. You can also see the total number of borrows and returns in the library.");
        }

        private void Books_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Here you can see the books in the library. You can also see the books that you own.");
        }

        private void Borrows_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Here you can see the borrows in the library. You can also see the borrows that you made.");
        }

        private void Users_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Here you can see the users that have the library.");
        }

        private void Storage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Here you can see the storage in the library. You can also see the storage that you own.");
        }
        
        private void Minimize_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click here to minimize the window.");
        }

        private void Close_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click here to close the window.");
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
            SayPageSpecificClippyMessage();
        }

        private async void BooksBTN_Click(object sender, RoutedEventArgs e)
        {
            await booksHolderPage.LoadDataAsync();
            PageHolder.Content = booksHolderPage;

            SetBasicColor();
            BooksBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
            SayPageSpecificClippyMessage();
        }

        private void UserButton_ButtonClick(object sender, RoutedEventArgs e)
        {
            var window = new InfoUser(appUser);
            window.Owner = this;
            window.ShowDialog();
            SayPageSpecificClippyMessage();
        }

        private async void BorrowsBTN_Click(object sender, RoutedEventArgs e)
        {
            await borrowsPage.LoadDataAsync();
            PageHolder.Content = borrowsPage;

            SetBasicColor();
            BorrowsBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
            SayPageSpecificClippyMessage();
        }

        private async void UsersBTN_Click(object sender, RoutedEventArgs e)
        {
            await usersPage.LoadDataAsync();
            PageHolder.Content = usersPage;

            SetBasicColor();
            UsersBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
            SayPageSpecificClippyMessage();
        }

        private async void StorageBTN_Click(object sender, RoutedEventArgs e)
        {
            await storagePage.LoadDataAsync();
            PageHolder.Content = storagePage;

            SetBasicColor();
            StorageBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
            SayPageSpecificClippyMessage();
        }


        private void SetBasicColor()
        {
            HomeBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            BooksBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            BorrowsBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            UsersBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
            StorageBTN.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3a3960"));
        }

        private void SayPageSpecificClippyMessage()
        {
            if (!ClippyService.IsVisible) return;

            switch (PageHolder.Content)
            {
                case HomePage:
                    ClippyService.Say("This is the Home Page. You can view overall stats here.");
                    break;
                case BooksHolderPage:
                    ClippyService.Say("This is the Books Page. You can browse and manage library books here.");
                    break;
                case BorrowsPage:
                    ClippyService.Say("This is the Borrows Page. Here you can manage book borrowings.");
                    break;
                case UsersPage:
                    ClippyService.Say("This is the Users Page. Manage library users here.");
                    break;
                case StoragePage:
                    ClippyService.Say("This is the Storage Page. View and manage storage-related data.");
                    break;
                default:
                    ClippyService.Say("You're viewing an unknown page.");
                    break;
            }
        }


    }
}
