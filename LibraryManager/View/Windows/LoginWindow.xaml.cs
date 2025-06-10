using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.Services;
using LibraryManager.View.Pages;
using LibraryManager.ViewModel;
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
        
        private LoginPage loginPage;
        private RegisterPage registerPage;
        private PersonalInfoPage personalInfoPage;

        private readonly Brush _pageSelectedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e2d4b"));
        private readonly Brush _pageNotSelectedColor = Brushes.Transparent;

        public LoginWindow()
        {
            InitializeComponent();
            
            loginPage = new LoginPage(this);
            registerPage = new RegisterPage(this);

            LoginButton.Background = _pageSelectedColor;
            RegisterButton.Background = _pageNotSelectedColor;


            WindowContent.Content = loginPage;

            this.PreviewKeyDown += OnKeyDown;

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                ClippyService.ToggleVisibility();
                 if (ClippyService.IsVisible)
                    ClippyService.Say("Insert your username and password. Click the login button after input. If you don't have an account, click the register button.");
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = loginPage;

            LoginButton.Background = _pageSelectedColor;
            RegisterButton.Background = _pageNotSelectedColor;

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = registerPage;

            LoginButton.Background = _pageNotSelectedColor;
            RegisterButton.Background = _pageSelectedColor;
        }
    }
}
