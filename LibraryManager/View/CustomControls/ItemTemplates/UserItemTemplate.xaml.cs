using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;

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

            Loaded += UserItemTemplate_Loaded;
        }

        private void UserItemTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            var userData = DataContext as User;

            if (userData == null)
            {
                return;
            }


            if((Role)userData.Role == Role.Admin)
            {
                deleteButton.Visibility = Visibility.Collapsed;
                editButton.Visibility = Visibility.Collapsed;
            }

        }
    }
}
