using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ArrayGridDemo
{
    public class ThresholdToBrushConverter : IValueConverter
    {
        public double Threshold { get; set; } = 300;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (double.TryParse(value.ToString(), out var number))
            {
                if (number > Threshold)
                    return "Red";

            }

            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
