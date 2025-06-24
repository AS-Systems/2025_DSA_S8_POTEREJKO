using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LibraryManager.Model.Repositories;
using System.Linq;

namespace LibraryManager.View.CustomControls.Capsules
{
    public partial class TopGenre : UserControl, INotifyPropertyChanged
    {
        public TopGenre()
        {
            InitializeComponent();
            DataContext = this;

            // Example data
            TopGenresList = new ObservableCollection<string> { "Fantasy", "Sci-Fi", "Horror" };
        }

        public static readonly DependencyProperty CapsuleWidthProperty =
            DependencyProperty.Register(nameof(CapsuleWidth), typeof(int), typeof(TopGenre), new PropertyMetadata(250));

        public static readonly DependencyProperty CapsuleHeightProperty =
            DependencyProperty.Register(nameof(CapsuleHeight), typeof(int), typeof(TopGenre), new PropertyMetadata(350));

        public static readonly DependencyProperty HeaderTopFontSizeProperty =
            DependencyProperty.Register(nameof(HeaderTopFontSize), typeof(int), typeof(TopGenre), new PropertyMetadata(45));

        public static readonly DependencyProperty HeaderBottomFontSizeProperty =
            DependencyProperty.Register(nameof(HeaderBottomFontSize), typeof(int), typeof(TopGenre), new PropertyMetadata(35));

        public static readonly DependencyProperty CapsuleCornerRadiusProperty =
            DependencyProperty.Register(nameof(CapsuleCornerRadius), typeof(int), typeof(TopGenre), new PropertyMetadata(65));

        public static readonly DependencyProperty TopGenresListProperty =
            DependencyProperty.Register(nameof(TopGenresList), typeof(ObservableCollection<string>), typeof(TopGenre),
                new PropertyMetadata(new ObservableCollection<string>(), OnTopGenresListChanged));

        public int CapsuleWidth
        {
            get => (int)GetValue(CapsuleWidthProperty);
            set => SetValue(CapsuleWidthProperty, value);
        }

        public int CapsuleHeight
        {
            get => (int)GetValue(CapsuleHeightProperty);
            set => SetValue(CapsuleHeightProperty, value);
        }

        public int HeaderTopFontSize
        {
            get => (int)GetValue(HeaderTopFontSizeProperty);
            set => SetValue(HeaderTopFontSizeProperty, value);
        }

        public int HeaderBottomFontSize
        {
            get => (int)GetValue(HeaderBottomFontSizeProperty);
            set => SetValue(HeaderBottomFontSizeProperty, value);
        }

        public int CapsuleCornerRadius
        {
            get => (int)GetValue(CapsuleCornerRadiusProperty);
            set => SetValue(CapsuleCornerRadiusProperty, value);
        }

        public ObservableCollection<string> TopGenresList
        {
            get => (ObservableCollection<string>)GetValue(TopGenresListProperty);
            set => SetValue(TopGenresListProperty, value);
        }

        private static void OnTopGenresListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TopGenre control)
            {
                if (e.OldValue is ObservableCollection<string> oldList)
                    oldList.CollectionChanged -= control.OnTopGenresListCollectionChanged;

                if (e.NewValue is ObservableCollection<string> newList)
                {
                    newList.CollectionChanged += control.OnTopGenresListCollectionChanged;
                    control.UpdateGenreTexts(newList);
                }
            }
        }

        private void OnTopGenresListCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateGenreTexts(TopGenresList);
        }

        private void UpdateGenreTexts(ObservableCollection<string> genres)
        {
            FirstGenreText = genres.Count > 0 ? genres[0] : "";
            SecondGenreText = genres.Count > 1 ? genres[1] : "";
            ThirdGenreText = genres.Count > 2 ? genres[2] : "";
        }
        public async Task LoadTopGenresAsync(IGenreRepository genreRepo, int top = 3)
        {
            var topGenres = await genreRepo.GetTopGenresAsync(top);
            // Map genre entities to string list of names
            var genreNames = new ObservableCollection<string>(topGenres.Select(g => g.Name));
            TopGenresList = genreNames;
        }


        private string _firstGenreText;
        public string FirstGenreText
        {
            get => _firstGenreText;
            set
            {
                _firstGenreText = value;
                OnPropertyChanged(nameof(FirstGenreText));
            }
        }

        private string _secondGenreText;
        public string SecondGenreText
        {
            get => _secondGenreText;
            set
            {
                _secondGenreText = value;
                OnPropertyChanged(nameof(SecondGenreText));
            }
        }

        private string _thirdGenreText;
        public string ThirdGenreText
        {
            get => _thirdGenreText;
            set
            {
                _thirdGenreText = value;
                OnPropertyChanged(nameof(ThirdGenreText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
