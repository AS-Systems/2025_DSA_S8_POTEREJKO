using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.Comboboxes
{
    /// <summary>
    /// Logika interakcji dla klasy MultiSelectComboBox.xaml
    /// </summary>
    public partial class MultiSelectComboBox : UserControl, INotifyPropertyChanged
    {
        public MultiSelectComboBox()
        {
            InitializeComponent();
            ListBox.SelectionChanged += ListBox_SelectionChanged;
        }

        public string PlaceHolderText
        {
            get { return (string)GetValue(PlaceHolderTextProperty); }
            set { SetValue(PlaceHolderTextProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.Register(
                nameof(PlaceHolderText),
                typeof(string),
                typeof(MultiSelectComboBox),
                new PropertyMetadata("Select", OnPlaceHolderTextChanged));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(MultiSelectComboBox));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(nameof(SelectedItems), typeof(IList), typeof(MultiSelectComboBox),
                new FrameworkPropertyMetadata(new List<object>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemsChanged));

        public IList SelectedItems
        {
            get => (IList)GetValue(SelectedItemsProperty);
            set => SetValue(SelectedItemsProperty, value);
        }

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged();
            }
        }

        public string SelectedItemsDisplay =>
            SelectedItems != null && SelectedItems.Count > 0
                ? string.Join(", ", SelectedItems.Cast<object>().Select(i => GetItemDisplayValue(i)))
                : PlaceHolderText;

        private string GetItemDisplayValue(object item)
        {
            var prop = item.GetType().GetProperty("DisplayName");
            return prop?.GetValue(item)?.ToString() ?? item.ToString();
        }

        private static void OnPlaceHolderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MultiSelectComboBox;
            control?.OnPropertyChanged(nameof(SelectedItemsDisplay));
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MultiSelectComboBox control)
            {
                control.SyncSelectedItems();
                control.OnPropertyChanged(nameof(SelectedItemsDisplay));
            }
        }

        private void SyncSelectedItems()
        {
            if (ListBox == null || SelectedItems == null) return;

            ListBox.SelectionChanged -= ListBox_SelectionChanged;

            ListBox.SelectedItems.Clear();
            foreach (var item in SelectedItems)
            {
                if (ItemsSource != null && ItemsSource.Cast<object>().Contains(item))
                    ListBox.SelectedItems.Add(item);
            }

            ListBox.SelectionChanged += ListBox_SelectionChanged;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItems == null)
                SelectedItems = new List<object>();

            foreach (var item in e.AddedItems)
            {
                if (!SelectedItems.Contains(item))
                    SelectedItems.Add(item);
            }

            foreach (var item in e.RemovedItems)
            {
                if (SelectedItems.Contains(item))
                    SelectedItems.Remove(item);
            }

            OnPropertyChanged(nameof(SelectedItemsDisplay));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public void ForceUpdateSelection()
        {
            if (ListBox == null || SelectedItems == null || ItemsSource == null) return;

            ListBox.SelectionChanged -= ListBox_SelectionChanged;

            ListBox.SelectedItems.Clear();

            foreach (var item in SelectedItems)
            {
                if (ItemsSource.Cast<object>().Contains(item))
                {
                    ListBox.SelectedItems.Add(item);
                }
            }

            ListBox.SelectionChanged += ListBox_SelectionChanged;

            OnPropertyChanged(nameof(SelectedItemsDisplay));
        }


    }
}