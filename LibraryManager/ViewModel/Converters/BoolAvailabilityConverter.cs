using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LibraryManager.ViewModel.Converters
{
    public class BoolAvailabilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            { 
                var bookCopies = (List<BookCopy>)value;

                bool available = bookCopies.Any(b => b.IsAvailable);

                if (available)
                {
                    return "Yes";
                }
                return "No";
            }
            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
