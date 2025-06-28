using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.Windows;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LibraryManager.Services;
using System.Windows.Input;

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

            DataContext = this;

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

        private async void CircularSingleButtonControl_ButtonSubClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new AdddBorrow();
            window.Owner = Window.GetWindow(this);
            await window.LoadDataAsync();

            var result = window.ShowDialog();
            if (result == true)
            {
                await LoadDataAsync();
            }

        }

        private void Title_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Title of the book.");
        }

        private void Borrower_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the borrower.");
        }

        private void Take_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Date when the book was taken.");
        }

        private void Return_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Date when the book should be returned.");
        }

        private void Copy_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the book copy owner.");
        }

        private void Field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can hover over fields to get more information.");
        }
    }
}
