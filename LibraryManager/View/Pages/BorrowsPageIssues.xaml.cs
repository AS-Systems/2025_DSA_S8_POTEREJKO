using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowsPageCheckOuts.xaml
    /// </summary>
    public partial class BorrowsPageCheckOuts : Page
    {
        private readonly IBorrowRepository _borrowRepository;
        public ObservableCollection<Borrow> IssuesList { get; set; } = new();

        public BorrowsPageCheckOuts()
        {
            InitializeComponent();
            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();

            DataContext = this;
        }

        private async void BorrowCycleItemTemplate_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            await LoadDataAsync();
        }


        public async Task LoadDataAsync()
        {
            var borrows = await _borrowRepository.GetUpcomingBorrowsOfBookCopyOwnerId(AppUser.User.Id);
            
            IssuesList.Clear();
            foreach (var borrow in borrows) 
            {
                IssuesList.Add(borrow);    
            }
        
        }

    }
}
