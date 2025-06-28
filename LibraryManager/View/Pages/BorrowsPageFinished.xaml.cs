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
    /// Logika interakcji dla klasy BorrowsPageFinished.xaml
    /// </summary>
    public partial class BorrowsPageFinished : Page
    {
        private readonly IBorrowRepository _borrowRepository;
        public ObservableCollection<Borrow> Borrows { get; set; } = new ObservableCollection<Borrow>();


        public BorrowsPageFinished()
        {
            InitializeComponent();
            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();

            DataContext = this;
        }


        public async Task LoadDataAsync()
        {
            IEnumerable<Borrow> results = await _borrowRepository.GetFinishedBorrowsOfUserId(AppUser.User.Id);

            Borrows.Clear();
            foreach (var borrow in results)
            {
                Borrows.Add(borrow);
            }

        }

        private void Title_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Title of the book.");
        }

        private void Borrower_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the borrower.");
        }

        private void Take_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Date when the book was taken.");
        }

        private void Return_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Date when the book was returned.");
        }

        private void Owner_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Name of the book copy owner.");
        }
                    
        private void Field_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can hover over the fields to get more information.");
        }
    }
}
