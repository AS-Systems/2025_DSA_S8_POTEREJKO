using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using System.Windows;
using System.Windows.Input;


namespace LibraryManager.View.Windows.Info
{
    /// <summary>
    /// Logika interakcji dla klasy InfoBorrow.xaml
    /// </summary>
    public partial class InfoBorrow : Window
    {
        public InfoBorrow(Borrow borrow)
        {
            InitializeComponent();
            BookLabel.Content = borrow.BookCopy.Book.Title.ToString();
            BorrowerLabel.Content = borrow.User.Username.ToString();
            BorrowDateLabel.Content = borrow.BorrowDate.ToShortDateString();
            ReturnDateLabel.Content = borrow.ReturnDate.ToShortDateString();
            BorrowStatusLabel.Content = ((Status)borrow.Status).ToString();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
