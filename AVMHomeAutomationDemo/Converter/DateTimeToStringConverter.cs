using System;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{

    [ValueConversion(typeof(DateTime?), typeof(string))]
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime? val = (DateTime?)value;
            return val.HasValue ? val.ToString() : "---";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
