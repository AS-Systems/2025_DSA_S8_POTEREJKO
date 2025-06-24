using LibraryManager.Model.Entities;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Info
{
    /// <summary>
    /// Logika interakcji dla klasy InfoBook.xaml
    /// </summary>
    public partial class InfoBookCopy : Window
    {
        public InfoBookCopy(BookCopy bookCopy)
        {
            InitializeComponent();

            availableBox.IsChecked = bookCopy.IsAvailable;
            txtBook.Text = bookCopy.Book?.Title;
            txtShelf.Text = bookCopy.Shelf?.Bookshelf?.Name +": " + bookCopy.Shelf?.Name;
            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");

        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
