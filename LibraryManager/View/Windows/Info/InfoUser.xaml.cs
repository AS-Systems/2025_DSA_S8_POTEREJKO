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
using LibraryManager.Model.Enums;

namespace LibraryManager.View.Windows.Info
{
    /// <summary>
    /// Logika interakcji dla klasy InfoUser.xaml
    /// </summary>
    public partial class InfoUser : Window
    {
        public InfoUser(User user)
        {
            InitializeComponent();

            NameLabel.Content = user.Name;
            SurnameLabel.Content = user.Surname;
            EmailLabel.Content = user.Email;
            PhoneLabel.Content = user.PhoneNumber;
            RoleLabel.Content = ((Role)user.Role).ToString();

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
