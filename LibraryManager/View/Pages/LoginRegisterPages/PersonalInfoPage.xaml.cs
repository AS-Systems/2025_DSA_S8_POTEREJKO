using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Logika interakcji dla klasy PersonalInfoPage.xaml
    /// </summary>
    public partial class PersonalInfoPage : Page
    {
        private User user = new();
        private readonly Window _window;
        private readonly IUserRepository _userRepository;

        private bool _isNameCorrect = false;
        private bool _isSurnameCorrect = false;
        private bool _isPhoneCorrect = false;


        public PersonalInfoPage(string email, string username, string password, Window window)
        {
            InitializeComponent();
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();

            _window = window;

            user.Email = email;
            user.Username = username;
            user.Password = password;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }

        private async void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            if (_isNameCorrect && _isSurnameCorrect && _isPhoneCorrect)
            {
                user.Name = FormatText(NameBox.Text);
                user.Surname = FormatText(SurnameBox.Text);
                user.PhoneNumber = PhoneBox.Text;
                user.Role = (int)Role.User;
                await _userRepository.InsertAsync(user);

                new MainWindow2(user).Show();
                _window.Close();
            }

        }

        private string FormatText(string textToFormat)
        {
            var lower = textToFormat.ToLower();
            var formatted = char.ToUpper(lower[0]) + lower.Substring(1);
            return formatted;

        }

        private bool ValidateName()
        {
            string namePattern = @"^[a-zA-Z]+$";

            if (!Regex.IsMatch(NameBox.Text, namePattern))
            {
                return false;
            }

            return true;
        }

        private bool ValidateSurname()
        {
            string namePattern = @"^[a-zA-Z]+$";

            if (!Regex.IsMatch(NameBox.Text, namePattern))
            {
                return false;
            }

            return true;
        }

        private bool ValidatePhone()
        {
            string phonePattern = @"^\+?[1-9]\d{0,2}[\s\-\.]?\(?\d{1,4}\)?[\s\-\.]?\d{1,4}[\s\-\.]?\d{1,9}$";

            if (!Regex.IsMatch(PhoneBox.Text, phonePattern))
            {
                return false;
            }

            return true;
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isNameCorrect = ValidateName();
        }

        private void SurnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isSurnameCorrect = ValidateSurname();
        }

        private void PhoneBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isPhoneCorrect = ValidatePhone();
        }

    }
}
