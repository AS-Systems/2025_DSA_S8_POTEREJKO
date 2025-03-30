using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
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

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserRepository _userRepository;
        public LoginWindow()
        {
            InitializeComponent();
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UsernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernameBox.Text = string.Empty;
        }

        private void UsernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text == string.Empty)
            {
                UsernameBox.Text = "Username";
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox.Text = string.Empty;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text == string.Empty)
            {
                PasswordBox.Text = "Password";
            }
        }

        private async void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var foundUser = await _userRepository.GetUserByUsernameAsync(username);

            if (foundUser != null)
            {
                if (foundUser.Password == PasswordBox.Text)
                {
                    MainWindow2 mainWindow = new MainWindow2(foundUser);
                    mainWindow.Show();
                    Close();
                }
                else { 
                    //To do: Info wrong password.
                }
            }
            else{
                //To do: Info user not found.
            }
        }
    }
}
