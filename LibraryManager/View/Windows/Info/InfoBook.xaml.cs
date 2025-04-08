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
    /// Logika interakcji dla klasy InfoBook.xaml
    /// </summary>
    public partial class InfoBook : Window
    {
        public InfoBook(Book book)
        {
            InitializeComponent();
            txtDescription.Text = book.Description;
            txtTitle.Text = book.Title;
            txtPage.Text = book.PageCount.ToString();
            cmbAuthor.Text = book.Author.ToString();
            cmbGenre.Text = book.Genre.ToString();
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
