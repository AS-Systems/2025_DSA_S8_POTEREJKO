using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibraryManager.Services;
using System.Windows.Input;

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
            var borrows = await _borrowRepository.GetCurrentBorrowsOfBookCopyOwnerId(AppUser.User.Id);

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

        private void Book_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Title of the book.");
        }

        private void Borrower_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the borrower.");
        }

        private void Return_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Date when the book should be returned.");
        }

        private void Field_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can hover over the fields to get more information.");
        }
    }
}
