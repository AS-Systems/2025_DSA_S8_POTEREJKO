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
    /// Logika interakcji dla klasy BorrowsPageFinished.xaml
    /// </summary>
    public partial class BorrowsPageFinished : Page
    {
        private readonly IBorrowRepository _borrowRepository;

        public ObservableCollection<Borrow> Borrows { get; set; }  = new ObservableCollection<Borrow>();


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
    }
}
