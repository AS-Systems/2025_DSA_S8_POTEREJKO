using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using LibraryManager.Services;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManager.View.Pages
{

    public partial class RegisterPage : Page, INotifyPropertyChanged
    {
        #region Private Fields

        private LoginWindow loginWindow;
        private readonly IUserRepository _userRepository;
        private readonly Brush _texboxNormalBorderBrush = (Brush)new BrushConverter().ConvertFromString("#5e686d");

        private bool isEmailCorrect = false;
        private bool isUsernameCorrect = false;
        private bool isPasswordCorrect = false;
        private bool emailPopVisibility;
        private string emailPopText;
        private bool usernamePopVisibility;
        private string usernamePopText;
        private bool passwordPopVisibility;
        private string passwordPopText;

        #endregion

        #region PublicFields

        public bool EmailPopVisibility
        {
            get { return emailPopVisibility; }
            set { emailPopVisibility = value;
                OnPropertyChanged();
            }
        }
        public string EmailPopText
        {
            get { return emailPopText; }
            set { emailPopText = value;
                OnPropertyChanged();
            }
        }
        public bool UsernamePopVisibility
        {
            get { return usernamePopVisibility; }
            set { usernamePopVisibility = value;
                  OnPropertyChanged();
            }
        }
        public string UsernamePopText
        {
            get { return usernamePopText; }
            set { usernamePopText = value;
                  OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public bool PasswordPopVisibility
        {
            get { return passwordPopVisibility; }
            set { passwordPopVisibility = value;
                OnPropertyChanged();
            }
        }
        public string PasswordPopText
        {
            get { return passwordPopText; }
            set { passwordPopText = value;
                OnPropertyChanged();
            }
        }
        #endregion


        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public RegisterPage(LoginWindow window)
        {
            InitializeComponent();
            loginWindow = window;
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();
            DataContext = this;


            EmailPopVisibility = false;
            EmailBox.BorderBrush = _texboxNormalBorderBrush;

            PasswordPopVisibility = false;
            PasswordBox.BorderBrush = _texboxNormalBorderBrush;

            UsernamePopVisibility = false;
            UsernameBox.BorderBrush = _texboxNormalBorderBrush;

        }

        private void ContinueBTN_Click(object sender, RoutedEventArgs e)
        {


            if(isEmailCorrect && isPasswordCorrect && isUsernameCorrect) 
            {
                loginWindow.WindowContent.Content = new PersonalInfoPage(EmailBox.Text,UsernameBox.Text,PasswordBox.Password, loginWindow);
            }

        }


        private async Task<bool> EvaluateUsernameAsync()
        {
            if (string.IsNullOrEmpty(UsernameBox.Text))
            {
                UsernamePopVisibility = true;
                UsernameBox.BorderBrush = Brushes.Red;
                UsernamePopText = "Username can't be empty!";
                return false;
            }

            if (_userRepository != null)
            {
                var result = await _userRepository.GetUserByUsernameAsync(UsernameBox.Text);
                if (result != null)
                {
                    UsernamePopVisibility = true;
                    UsernameBox.BorderBrush = Brushes.Red;
                    UsernamePopText = "Username taken!";
                    return false;
                }
            }

            UsernamePopVisibility = false;
            UsernameBox.BorderBrush = _texboxNormalBorderBrush;
            return true;
        }


        private bool EvaluateEmail()
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            if (string.IsNullOrEmpty(EmailBox.Text))
            {
                EmailPopVisibility = true;
                EmailPopText = "E-mail can't be empty!";
                EmailBox.BorderBrush = Brushes.Red;
                return false;
            }

            if (!Regex.IsMatch(EmailBox.Text, emailPattern))
            {
                EmailPopVisibility = true;
                EmailPopText = "Invalid E-mail!";
                EmailBox.BorderBrush = Brushes.Red;
                return false;
            }

            EmailBox.BorderBrush = _texboxNormalBorderBrush;
            EmailPopVisibility = false;
            return true;
        }

        private bool EvaluatePassword()
        {
            //Password must be at least 8 characters, with at least:
            // - one uppercase letter
            // - one lowercase letter
            // - one digit
            // - one special character (!@#$%^&*)
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$";
            if (!Regex.IsMatch(PasswordBox.Password, passwordPattern))
            {
                PasswordPopVisibility = true;
                PasswordBox.BorderBrush = Brushes.Red;
                PasswordPopText = @" Password must be at least 8 characters, with at least:
                                - one uppercase letter
                                - one lowercase letter
                                - one digit
                                - one special character (!@#$%^&*)";

                return false;
            }

            PasswordBox.BorderBrush = _texboxNormalBorderBrush;
            PasswordPopVisibility = false;
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateEmailPlaceHolder();
        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateEmailPlaceHolder();
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEmailCorrect = EvaluateEmail();
            UpdateEmailPlaceHolder();
        }

        private void UpdateEmailPlaceHolder()
        {
            PlaceholderTextEmail.Visibility = string.IsNullOrEmpty(EmailBox.Text)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }

        private void UsernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateUsernamePlaceHolder();
        }
        private async void UsernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            isUsernameCorrect = await EvaluateUsernameAsync();
            UpdateUsernamePlaceHolder();
        }
        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsernamePlaceHolder();
        }
        private void UpdateUsernamePlaceHolder()
        {
            PlaceholderTextUsername.Visibility = string.IsNullOrEmpty(UsernameBox.Text)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdatePasswordPlaceHolder();
        }
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdatePasswordPlaceHolder();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPasswordCorrect = EvaluatePassword();
            UpdatePasswordPlaceHolder();
        }
        private void UpdatePasswordPlaceHolder()
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(PasswordBox.Password)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }
        private void UsernameBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Enter your desired username.");
        }
        private void EmailBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Enter your email.");
        }
        private void PasswordBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Enter your desired password.");
        }
        private void ContinueBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click here after filling out the fields.");
        }
        private void ExitBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click here to exit application.");
        }
        private void MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Enter your email, username and password to register. After filling out the fields, click 'Continue' to save your user.");
        }
    }
}
