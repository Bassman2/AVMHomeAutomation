using System;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{
    [ValueConversion(typeof(double?), typeof(string))]
    public class DoubleToCelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double? val = (double?)value;
            if (val.HasValue)
            {
                if (val.Value == double.MaxValue)
                {
                    return "On";
                }
                else if (val.Value == double.MinValue)
                {
                    return "Off";
                }
                else
                {
                    return $"{val.Value:N1} °C";
                }
            }
            return "--.- °C";            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
