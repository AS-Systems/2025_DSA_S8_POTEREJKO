using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Info
{
    /// <summary>
    /// Logika interakcji dla klasy InfoUser.xaml
    /// </summary>
    public partial class InfoUser : Window
    {
        private readonly IImageConverter _imageConverter;

        public InfoUser(User user)
        {
            InitializeComponent();
            _imageConverter = App.ServiceProvider.GetRequiredService<IImageConverter>();


            if (user.ProfilePicture is not null)
            {
                profileDispay.DisplayImageSource = _imageConverter.BlobToImage(user.ProfilePicture);
            }
           
            NameLabel.Content = user.Name;
            SurnameLabel.Content = user.Surname;
            EmailLabel.Content = user.Email;
            PhoneLabel.Content = user.PhoneNumber;
            RoleLabel.Content = ((Role)user.Role).ToString();
            UsernameLabel.Content = user.Username;

            CloseBTN.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "close.png");
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
