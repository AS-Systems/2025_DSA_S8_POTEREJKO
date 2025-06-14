using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace LibraryManager.ViewModel.Converters
{
    public class GenresToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string genreString = string.Empty;

            if (value is null)
            { 
                return genreString;
            }

            var genres = (ICollection<BooksGenre>)value;

            foreach (var genre in genres)
            {
                genreString += (genre.Genre?.Name + ", ");
            }

            return genreString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
