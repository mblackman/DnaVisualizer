using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DnaVisualizer
{
    /// <summary>
    /// A converter to set visiblity based on a string being null or empty.
    /// </summary>
    public class StringNullOrEmptyToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => string.IsNullOrEmpty(value as string) ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;

        public override object ProvideValue(IServiceProvider serviceProvider) => null;
    }
}
