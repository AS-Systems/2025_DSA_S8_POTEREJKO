using LibraryManager.Model.Entities;
using LibraryManager.View.Windows.Info;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.ItemTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowsItemTemplate.xaml
    /// </summary>
    public partial class BorrowsItemTemplate : UserControl
    {
        public BorrowsItemTemplate()
        {
            InitializeComponent();
            actionBtn.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "info.png");

        }

        private void actionBtn_ItemClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is Borrow borrow)
            {
                var window = new InfoBorrow(borrow);
                window.Owner = Window.GetWindow(this);
                window.ShowDialog();
            }
        }
    }
}
