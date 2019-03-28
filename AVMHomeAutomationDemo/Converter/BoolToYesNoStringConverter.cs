using System;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{

    [ValueConversion(typeof(bool), typeof(string))]
    public class BoolToYesNoStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
