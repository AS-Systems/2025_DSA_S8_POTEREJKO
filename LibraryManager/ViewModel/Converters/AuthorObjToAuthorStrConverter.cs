﻿using LibraryManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace LibraryManager.ViewModel.Converters
{
    class AuthorObjToAuthorStrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            { 
                var authors = (ICollection<BookAuthor>)value;
                string authorNameSurname = string.Empty;

                foreach (var bookAuthor in authors) 
                {
                   authorNameSurname = bookAuthor.Author?.Name + " " + bookAuthor.Author?.Surname + " ";
                }

                return authorNameSurname;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
