using System;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{
    [ValueConversion(typeof(double?), typeof(string))]
    public class DoubleToUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Unit unit = (Unit)parameter;
            double? val = (double?)value;
            switch (unit)
            {
            case Unit.Temperature:
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
                //return val.HasValue ? $"{val.Value:N1} °C" : $"--.- °C";
            case Unit.Power:
                return val.HasValue ? $"{val.Value:N3} W" : $"--.--- W";
            case Unit.Energy:
                return val.HasValue ? $"{val.Value:N3} kWh" : $"--.--- kWh";
            case Unit.Voltage:
                return val.HasValue ? $"{val.Value:N3} V" : $"--.--- V";
            default:
                return "---";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public enum Unit
    {
        Temperature,
        Power,
        Energy,
        Voltage,
    }
}
