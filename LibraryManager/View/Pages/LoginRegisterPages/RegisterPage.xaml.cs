using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManager.View.Pages
{

    public partial class RegisterPage : Page, INotifyPropertyChanged
    {
        private LoginWindow loginWindow;
        private readonly IUserRepository _userRepository;

        private bool isEmailCorrect = false;
        private bool isUsernameCorrect = false;
        private bool isPasswordCorrect = false;

        private readonly Brush _texboxNormalBorderBrush = (Brush)new BrushConverter().ConvertFromString("#5e686d");



        private bool emailPopVisibility;

        public bool EmailPopVisibility
        {
            get { return emailPopVisibility; }
            set { emailPopVisibility = value;
                OnPropertyChanged();
            }
        }

        private string emailPopText;

        public string EmailPopText
        {
            get { return emailPopText; }
            set { emailPopText = value;
                OnPropertyChanged();
            }
        }

        private bool usernamePopVisibility;
        public bool UsernamePopVisibility
        {
            get { return usernamePopVisibility; }
            set { usernamePopVisibility = value;
                  OnPropertyChanged();
            }
        }

        private string usernamePopText;

        public string UsernamePopText
        {
            get { return usernamePopText; }
            set { usernamePopText = value;
                  OnPropertyChanged();
            }
        }


        private bool passwordPopVisibility;
        public bool PasswordPopVisibility
        {
            get { return passwordPopVisibility; }
            set { passwordPopVisibility = value;
                OnPropertyChanged();
            }
        }

        private string passwordPopText;
        public string PasswordPopText
        {
            get { return passwordPopText; }
            set { passwordPopText = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
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
                loginWindow.WindowContent.Content = new PersonalInfoPage(EmailBox.Text,UsernameBox.Text,PasswordBox.Text, loginWindow);
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
            if (!Regex.IsMatch(PasswordBox.Text, passwordPattern))
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

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEmailCorrect = EvaluateEmail();
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPasswordCorrect = EvaluatePassword();
        }

        private async void UsernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            isUsernameCorrect = await EvaluateUsernameAsync();
        }
    }
}
