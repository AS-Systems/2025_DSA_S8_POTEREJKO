using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Edit
{
    /// <summary>
    /// Logika interakcji dla klasy EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private User updatedUser;
        private readonly IUserRepository _userRepository;

        public EditUser(User user, bool canShowRole)
        {
            InitializeComponent();
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();    

            updatedUser = user;

            nameBox.Text = user.Name;
            surnameBox.Text = user.Surname;
            emailBox.Text = user.Email;
            phoneBox.Text = user.PhoneNumber;
            roleCombo.ItemsSource = Enum.GetValues(typeof(Role));
            roleCombo.SelectedItem = (Role)user.Role;

            if (canShowRole)
            {
                roleCombo.Visibility = Visibility.Visible;
            }
            else 
            {
                roleCombo.Visibility = Visibility.Collapsed;
            }

        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Role selectedRole = (Role)roleCombo.SelectedItem;

            if (profileHolder.ImageBlob is not null || profileHolder.ImageBlob?.Length > 0) 
            {
                updatedUser.ProfilePicture = profileHolder.ImageBlob;
            }


            updatedUser.Name = nameBox.Text;
            updatedUser.Surname = surnameBox.Text;
            updatedUser.Email = emailBox.Text;
            updatedUser.PhoneNumber = phoneBox.Text;
            updatedUser.Role = (sbyte)((int)selectedRole);

            await _userRepository.UpdateAsync(updatedUser);

            MessageBox.Show("User updated!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }
    }
}
