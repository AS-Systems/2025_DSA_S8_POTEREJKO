using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Add
{
    /// <summary>
    /// Logika interakcji dla klasy AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private readonly IUserRepository _userRepository;


        public AddUser()
        {
            InitializeComponent();

            roleComboBox.ItemsSource = Enum.GetValues(typeof(Role));
            roleComboBox.SelectedItem = Role.User;

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

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            // Validate data

            var image = imageProfile.ImageBlob;

            if (image is null)
            {
                image = [];
            }


            var newUser = new User
            {
                Username = usernameTextBox.Text,
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                Role = Convert.ToSByte((int)roleComboBox.SelectedItem),
                PhoneNumber = phoneTextBox.Text,
                Email = mailTextBox.Text,
                ProfilePicture = imageProfile.ImageBlob,
                Password = passwordTextBox.Text
            };


            await _userRepository.InsertAsync(newUser);

        }
    }
}
