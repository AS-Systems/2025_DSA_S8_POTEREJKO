using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            IEnumerable<Borrow> results = await _borrowRepository.GetFinishedBorrowsOfUserId(AppUser.User.Id);

            Borrows.Clear();
            foreach (var borrow in results)
            {
                Borrows.Add(borrow);
            }

        }

    }
}
