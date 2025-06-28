using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryManager.Services;

namespace LibraryManager.View.Pages
{

    public partial class BorrowsPageCurrent : Page
    {
        private readonly IBorrowRepository _borrowRepository;
        public ObservableCollection<Borrow> Borrows { get; set; } = new ObservableCollection<Borrow>();

        public BorrowsPageCurrent()
        {
            InitializeComponent();
            DataContext = this;

            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();
        }


        public async Task LoadDataAsync()
        {
            IEnumerable<Borrow> results = await _borrowRepository.GetCurrentBorrowsOfUserId(AppUser.User.Id);

            Borrows.Clear();
            foreach (var borrow in results)
            {
                Borrows.Add(borrow);
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

        private void Owner_MouseEnter(object sender, MouseEventArgs e)
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
