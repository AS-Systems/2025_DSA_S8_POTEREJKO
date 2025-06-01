using LibraryManager.Model.Entities;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {

        public ObservableCollection<User> FilteredUsers { get; set; } = new ObservableCollection<User>();

        public UsersPage()
        {
            InitializeComponent();


            FilteredUsers.Add(

                new User()
                {
                    Name = "Name1",
                    Surname = "Surname1",
                    Username = "UserName1",
                    Role = 0
                }
                );

            FilteredUsers.Add(

               new User()
               {
                   Name = "Name2",
                   Surname = "Surname2",
                   Username = "UserName2",
                   Role = 1
               }
               );

            DataContext = this;
        }
    }
}
