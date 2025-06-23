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
    /// Logika interakcji dla klasy BorrowsPageReturns.xaml
    /// </summary>
    public partial class BorrowsPageReturns : Page
    {
        private readonly IBorrowRepository _borrowRepository;

        public ObservableCollection<Borrow> ReturnsList { get; set; } = new();

        public BorrowsPageReturns()
        {
            InitializeComponent();
            DataContext = this;

            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();    

        }

        public async Task LoadDataAsync()
        {
            var borrows =  await _borrowRepository.GetCurrentBorrowsOfBookCopyOwnerId(AppUser.User.Id);

            ReturnsList.Clear();
            foreach (var borrow in borrows) 
            {
                ReturnsList.Add(borrow);
            }

        }

        private async void BorrowCycleItemTemplate_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
