using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

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
    }
}
