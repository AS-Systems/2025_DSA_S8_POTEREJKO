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
using System.Xml.Linq;
using LibraryManager.Model.Entities;

namespace LibraryManager.View.Windows.Info
{
    /// <summary>
    /// Logika interakcji dla klasy InfoAuthor.xaml
    /// </summary>
    public partial class InfoAuthor : Window
    {
        public InfoAuthor(Author author)
        {
            InitializeComponent();
            NameLabel.Content = author.Name;
            SurnameLabel.Content = author.Surname;
            InfoContent.Text = author.Info;
            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");
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
