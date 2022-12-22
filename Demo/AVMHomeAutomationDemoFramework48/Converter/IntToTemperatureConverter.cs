using System;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{
    /// <summary>
    /// Converter int to temperatur in 0,5 °C, Wertebereich: 0x10 – 0x38 16 – 56 (8 bis 28°C), 16 <= 8°C, 17 = 8,5°C...... 56 >= 28°C, 254 = ON , 253 = OFF
    /// </summary>
    [ValueConversion(typeof(int), typeof(string))]
    public class IntToTemperatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = (int)value;
            if (val >= 16 && val <= 56)
            {
                return $"{val / 2.0:N1} °C";
            }
            else if (val == 253)
            {
                return "OFF";
            }
            else if (val == 254)
            { 
                return "ON";
            }
            return "???";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
