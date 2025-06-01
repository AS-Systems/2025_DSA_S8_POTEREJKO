using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        public ObservableCollection<Bookshelf> FilteredBookshelves { get; set; } = new ObservableCollection<Bookshelf>();
        public StoragePage()
        {
            InitializeComponent();
            DataContext = this;


            List<Shelf> shelfList = new List<Shelf>();

            var shelf = new Shelf()
            {
                Id = 1,
                Name = "Test",
                AvailableSpace = 3,
                Capacity = 7
            };
            shelfList.Add(shelf);


            FilteredBookshelves.Add(new Bookshelf(){
                Name = "Bookshelf1",
                HasSpace = true,
                Shelves = shelfList
            });

        }
    }
}
