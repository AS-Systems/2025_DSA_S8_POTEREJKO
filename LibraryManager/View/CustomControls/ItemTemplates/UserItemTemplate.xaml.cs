using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.View.Windows.Info;
using LibraryManager.ViewModel;
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

            
        }

        private void infoButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is User user)
            {
                var window = new InfoUser(user);
                window.ShowDialog();
            }
        }
    }
}
