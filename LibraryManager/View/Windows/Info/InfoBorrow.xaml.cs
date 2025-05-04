using LibraryManager.Model.Entities;
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
            BorrowerLabel.Content = borrow.User.ToString();
            BorrowDateLabel.Content = borrow.BorrowDate.ToString();
            ReturnDateLabel.Content = borrow.ReturnDate.ToString();
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
