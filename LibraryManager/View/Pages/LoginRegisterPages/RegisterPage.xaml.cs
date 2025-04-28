using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManager.View.Pages
{

    public partial class RegisterPage : Page
    {
        private LoginWindow loginWindow;
        private readonly IUserRepository _userRepository;

        private bool isEmailCorrect = false;
        private bool isUsernameCorrect = false;
        private bool isPasswordCorrect = false;


        public RegisterPage(LoginWindow window)
        {
            InitializeComponent();
            loginWindow = window;
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();

             
        }

        private void ContinueBTN_Click(object sender, RoutedEventArgs e)
        {

            if(isEmailCorrect && isPasswordCorrect && isUsernameCorrect) 
            {
                loginWindow.WindowContent.Content = new PersonalInfoPage(EmailBox.Text,UsernameBox.Text,PasswordBox.Text, loginWindow);
            }


        }


        private async Task<bool> EvaluateUsername()
        {
            if (string.IsNullOrEmpty(UsernameBox.Text))
            {
                return false;
            }

            if (_userRepository != null)
            {
                var result = await _userRepository.GetUserByUsernameAsync(UsernameBox.Text);
                if (result != null)
                {
                    return false;
                }
            }

            return true;
        }


        private bool EvaluateEmail()
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            if (string.IsNullOrEmpty(EmailBox.Text))
            { 
                return false;
            }

            if (!Regex.IsMatch(EmailBox.Text, emailPattern))
            {
                return false;
            }

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
                return false;
            }

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

        private async void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isUsernameCorrect = await EvaluateUsername();
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPasswordCorrect = EvaluatePassword();
        }
    }
}
