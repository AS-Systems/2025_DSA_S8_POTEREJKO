using LibraryManager.Model.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Info
{
    /// <summary>
    /// Logika interakcji dla klasy InfoBook.xaml
    /// </summary>
    public partial class InfoBookshelf : Window
    {
        public ObservableCollection<Shelf> Shelves { get; set; } = new ObservableCollection<Shelf>();


        public InfoBookshelf(Bookshelf bookshelf)
        {
            InitializeComponent();
            DataContext = this;

            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");

            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png");


            lbName.Text = bookshelf.Name;   
            lbCity.Content = bookshelf.City;
            lbCountry.Content = bookshelf.Country;
            lbStreet.Content = bookshelf.Street;

            Shelves.Clear();
            foreach (var shelf in bookshelf.Shelves)
            {
                Shelves.Add(shelf);
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
