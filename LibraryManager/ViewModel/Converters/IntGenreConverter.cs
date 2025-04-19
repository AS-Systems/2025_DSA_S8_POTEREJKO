using LibraryManager.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LibraryManager.ViewModel.Converters
{
    public class IntGenreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intVal && Enum.IsDefined(typeof(Genre), intVal))
            {
                var genre = (Genre)intVal;
                return GetEnumDescription(genre);
            }

            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string description)
            {
                var match = Enum.GetValues(typeof(Genre))
                    .Cast<Genre>()
                    .FirstOrDefault(g => GetEnumDescription(g).Equals(description, StringComparison.OrdinalIgnoreCase));

                return (int)match; 
            }

            return 0; 
        }


        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }
    }
}
