using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class PersonalInfoPage : Page, INotifyPropertyChanged
    {
        private User user = new();
        private readonly Window _window;
        private readonly IUserRepository _userRepository;

        private readonly Brush _texboxNormalBorderBrush = (Brush)new BrushConverter().ConvertFromString("#5e686d");

        private bool _isNameCorrect = false;
        private bool _isSurnameCorrect = false;
        private bool _isPhoneCorrect = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties Popups
        private bool namePopVisibility;
        private string namePopText;

        private bool surnamePopVisibility;
        private string surnamePopText;

        private bool phonePopVisibility;
        private string phonePopText;


        public bool NamePopVisibility
        {
            get { return namePopVisibility; }
            set { namePopVisibility = value;
                OnPropertyChanged();
            }
        }
        public string NamePopText
        {
            get { return namePopText; }
            set { namePopText = value;
                OnPropertyChanged();
            }
        }
        public bool SurnamePopVisibility
        {
            get { return surnamePopVisibility; }
            set { surnamePopVisibility = value;
                OnPropertyChanged();
            }
        }
        public string SurnamePopText
        {
            get { return surnamePopText; }
            set { surnamePopText = value;
                OnPropertyChanged();
            }
        }
        public bool PhonePopVisibility
        {
            get { return phonePopVisibility; }
            set { phonePopVisibility = value;
                OnPropertyChanged();
            }
        }
        public string PhonePopText
        {
            get { return phonePopText; }
            set { phonePopText = value;
                OnPropertyChanged();
            }
        }
        #endregion


        public PersonalInfoPage(string email, string username, string password, Window window)
        {
            InitializeComponent();
            DataContext = this;

            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();

            _window = window;

            user.Email = email;
            user.Username = username;
            user.Password = password;

            NameBox.BorderBrush = _texboxNormalBorderBrush;
            SurnameBox.BorderBrush = _texboxNormalBorderBrush;
            PhoneBox.BorderBrush = _texboxNormalBorderBrush;

            NamePopVisibility = false;
            SurnamePopVisibility = false;
            PhonePopVisibility = false;

        }

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

            if (string.IsNullOrEmpty(NameBox.Text))
            {
                NamePopVisibility = true;
                NamePopText = "Name can't be empty!";
                NameBox.BorderBrush = Brushes.Red;
                return false;
            }

            if (!Regex.IsMatch(NameBox.Text, namePattern))
            {
                NamePopVisibility = true;
                NamePopText = "Invalid name!";
                NameBox.BorderBrush = Brushes.Red;
                return false;
            }

            NamePopVisibility = false;
            NameBox.BorderBrush = _texboxNormalBorderBrush;
            return true;
        }

        private bool ValidateSurname()
        {
            string surnamePattern = @"^[a-zA-Z]+$";

            if (string.IsNullOrEmpty(SurnameBox.Text))
            {
                SurnamePopVisibility = true;
                SurnamePopText = "Surname can't be empty!";
                SurnameBox.BorderBrush = Brushes.Red;
                return false;
            }

            if (!Regex.IsMatch(SurnameBox.Text, surnamePattern))
            {
                SurnamePopVisibility = true;
                SurnamePopText = "Invalid surname!";
                SurnameBox.BorderBrush = Brushes.Red;
                return false;
            }

            SurnamePopVisibility = false;
            SurnameBox.BorderBrush = _texboxNormalBorderBrush;
            return true;
        }

        private bool ValidatePhone()
        {
            string phonePattern = @"^\+?[1-9]\d{0,2}[\s\-\.]?\(?\d{1,4}\)?[\s\-\.]?\d{1,4}[\s\-\.]?\d{1,9}$";

            if (!Regex.IsMatch(PhoneBox.Text, phonePattern))
            {
                PhonePopVisibility = true;
                PhonePopText = "Invalid phone number!";
                PhoneBox.BorderBrush = Brushes.Red;
                return false;
            }

            PhoneBox.BorderBrush = _texboxNormalBorderBrush;
            PhonePopVisibility = false;
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
