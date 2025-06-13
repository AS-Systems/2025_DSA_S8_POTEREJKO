using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowsPageUpcoming.xaml
    /// </summary>
    public partial class BorrowsPageUpcoming : Page
    {
        private readonly IBorrowRepository _borrowRepository;

        public ObservableCollection<Borrow> Borrows { get; set; } = new ObservableCollection<Borrow>();


        public BorrowsPageUpcoming()
        {
            InitializeComponent();
            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();
            
        }



        public async Task LoadDataAsync()
        {
            var results = await _borrowRepository.GetUpcomingBorrowsOfUserId(AppUser.User.Id);

            Borrows.Clear();
            foreach (var borrow in results)
            {
                Borrows.Add(borrow);
            }
        }

    }
}
