using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IImageConverter _imageConverter;

        public InfoBook(Book book)
        {
            InitializeComponent();
            _imageConverter = App.ServiceProvider.GetRequiredService<IImageConverter>();    

            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");
            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png");

            if (book.Cover is not null)
            {
                bookCoverPhoto.ImageDisplay.DisplayImageSource = _imageConverter.BlobToImage(book.Cover);
            }

            txtDescription.Text = book.Description;
            txtTitle.Text = book.Title;
            lbPage.Content = "~" + book.PageCount.ToString();
            lbIBAN.Content = book.Iban;

            foreach (var genre in book.BooksGenres)
            {
                lbGenre.Text += (genre.Genre.Name + ", ");
            }

            foreach (var author in book.BookAuthors)
            {
                txtAuthor.Text += (author.Author.DisplayName + ", ");
            }

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
