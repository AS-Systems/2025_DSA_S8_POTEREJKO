using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.CustomControls.Buttons
{
    /// <summary>
    /// Logika interakcji dla klasy UserInfoButton.xaml
    /// </summary>
    public partial class UserInfoButton : UserControl
    {
        public static readonly DependencyProperty AppUserProperty = DependencyProperty.Register("AppUser", typeof(User), typeof(UserInfoButton), new PropertyMetadata(new User()));


        public User AppUser
        {
            get { return (User)GetValue(AppUserProperty); }
            set { SetValue(AppUserProperty, value); }
        }
        



        public UserInfoButton()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler ButtonClick;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(this, e);
        }
    }
}
