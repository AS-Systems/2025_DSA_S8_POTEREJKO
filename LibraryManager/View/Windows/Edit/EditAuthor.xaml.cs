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
    /// Logika interakcji dla klasy EditAuthor.xaml
    /// </summary>
    public partial class EditAuthor : Window
    {
        public EditAuthor(Author author)
        {
            InitializeComponent();
            txtName.Text = author.Name;
            txtSurname.Text = author.Surname;
            txtInfo.Text = author.Info;
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
