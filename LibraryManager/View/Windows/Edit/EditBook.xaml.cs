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
using LibraryManager.Model.Entities;

namespace LibraryManager.View.Windows.Edit
{
    /// <summary>
    /// Logika interakcji dla klasy EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        public EditBook(Book book)
        {
            InitializeComponent();
            txtDescription.Text = book.Description;
            txtTitle.Text = book.Title;
            txtPage.Text = book.PageCount.ToString();
            cmbAuthor.Text = book.BookAuthors.ToString();
            cmbGenre.Text = book.BooksGenres.ToString();
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
