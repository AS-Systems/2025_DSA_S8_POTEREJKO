using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
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

            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");


            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png");
            BookCover.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));


            txtDescription.Text = book.Description;
            txtTitle.Text = book.Title;
            lbPage.Content = "~" + book.PageCount.ToString();
            lbAuthor.Text = (book.Author.Name + " " + book.Author.Surname);
            lbGenre.Content = (Genre)book.Genre;
            lbIBAN.Content = "3459876";
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
