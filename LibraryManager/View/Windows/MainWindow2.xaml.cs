using LibraryManager.Model.Entities;
using LibraryManager.View.Pages;
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
using System.Windows.Shapes;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        private BooksPage booksPage = new BooksPage();
        private HomePage homePage = new HomePage();

        public MainWindow2(User user)
        {
            InitializeComponent();
            UsernameLabel.Text = user.Name + " " + user.Surname;
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

        private void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.Content = homePage;
        }

        private void BooksBTN_Click(object sender, RoutedEventArgs e)
        {
            PageHolder.Content = booksPage;
        }
    }
}
