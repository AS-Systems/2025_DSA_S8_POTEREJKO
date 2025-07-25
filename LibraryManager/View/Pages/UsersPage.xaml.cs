﻿using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows.Add;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryManager.Services;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private readonly IUserRepository _userRepository;
        public ObservableCollection<User> FilteredUsers { get; set; } = new ObservableCollection<User>();

        public UsersPage()
        {
            InitializeComponent();
            DataContext = this;
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();

            if ((Role)AppUser.User.Role == Role.Admin)
            {
                cirButton.ButtonIsVisible = Visibility.Visible;
            }
            else
            {
                cirButton.ButtonIsVisible = Visibility.Hidden;
            }

        }


        public async Task LoadDataAsync()
        {
            var result = await _userRepository.GetAllUsersAsync();


            FilteredUsers.Clear();
            foreach (var user in result)
            {
                FilteredUsers.Add(user);
            }
        }

        private async void UserItemTemplate_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private async void cirButton_ButtonSubClick(object sender, RoutedEventArgs e)
        {
            var window = new AddUser();
            window.Owner = Window.GetWindow(this);

            var result = window.ShowDialog();

            if (result == true)
            {
                await LoadDataAsync();
            }
        }

        private void Username_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Username of the user.");
        }

        private void Name_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the user.");
        }

        private void Surname_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Surname of the user.");
        }

        private void Books_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Number of books offered by the user.");
        }

        private void Field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can hover over the fields to get more information.");
        }
    }
}
