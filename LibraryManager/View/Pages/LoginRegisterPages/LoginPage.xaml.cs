using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, INotifyPropertyChanged
    {
        private readonly Window _window;
        private readonly IUserRepository _userRepository;

        private bool loginPopVisibility;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool LoginPopVisibility
        {
            get { return loginPopVisibility; }
            set { loginPopVisibility = value;
                OnPropertyChanged();
            }
        }



        public LoginPage(Window window)
        {
            InitializeComponent();
            DataContext = this;

            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();
            _window = window;

            LoginPopVisibility = false;
        }

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }

        private void UsernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateUsernamePlaceHolder();
        }

        private void UsernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateUsernamePlaceHolder();
        }

        private void UsernameBox_TextChanged(object sender, RoutedEventArgs e)
        {
            UpdateUsernamePlaceHolder();
        }


        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdatePasswordPlaceholder();
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdatePasswordPlaceholder();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdatePasswordPlaceholder();
        }

        private void UpdatePasswordPlaceholder()
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(PasswordBox.Password)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void UpdateUsernamePlaceHolder()
        {
            PlaceholderTextUsername.Visibility = string.IsNullOrEmpty(UsernameBox.Text)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }


        private async void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var foundUser = await _userRepository.GetUserByUsernameAsync(username);

            if (foundUser != null)
            {
                if (foundUser.Password == PasswordBox.Password)
                {
                    MainWindow2 mainWindow = new MainWindow2(foundUser);
                    mainWindow.Show();
                    _window.Close();
                }
            }

            LoginPopVisibility = true;


        }

    }
}
