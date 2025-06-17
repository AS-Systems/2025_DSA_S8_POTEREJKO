using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows.Edit;
using LibraryManager.View.Windows.Info;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.ItemTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy UserItemTemplate.xaml
    /// </summary>
    public partial class UserItemTemplate : UserControl
    {
        private readonly IUserRepository _userRepository;

        public static readonly RoutedEvent DeletedEvent = EventManager.RegisterRoutedEvent(
        nameof(Deleted), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserItemTemplate));

        public event RoutedEventHandler Deleted
        {
            add { AddHandler(DeletedEvent, value); }
            remove { RemoveHandler(DeletedEvent, value); }
        }



        public UserItemTemplate()
        {
            InitializeComponent();
            deleteButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "delete.png");
            infoButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "info.png");
            editButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "edit.png");

            if ((Role)AppUser.User.Role == Role.User)
            {
                deleteButton.Visibility = Visibility.Collapsed;
                editButton.Visibility = Visibility.Collapsed;
            }

            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();
        }

        private void infoButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is User user)
            {
                var window = new InfoUser(user);
                window.Owner = Window.GetWindow(this);
                window.ShowDialog();
            }
        }

        private void editButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is User user)
            {
                var window = new EditUser(user: user, canShowRole: true);
                window.Owner = Window.GetWindow(this);
                var result = window.ShowDialog();

                if (result == true) 
                {
                    RaiseEvent(new RoutedEventArgs(DeletedEvent));
                }
            }
        }

        private async void deleteButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is User user)
            {
                string message = "Are you sure you want to delete: ";
                bool shouldCloseApplication = false;

                if (user == AppUser.User)
                {
                    message += "Your Account?";
                    shouldCloseApplication = true;
                }
                else 
                {
                    message += $"{user.Username}?";
                }    
                var result = MessageBox.Show(message, "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (result == MessageBoxResult.Yes)
                {
                    // Perform the delete logic here
                    await _userRepository.DeleteAsync(user);
                    var clicked = MessageBox.Show("Item deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                    RaiseEvent(new RoutedEventArgs(DeletedEvent));
                    if (clicked == MessageBoxResult.Yes && shouldCloseApplication) 
                    { 
                        App.Current.Shutdown();
                    }

                }
            }
        }
    }
}
