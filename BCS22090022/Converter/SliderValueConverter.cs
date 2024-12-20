using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCS22090022.Converter
{
    public class SliderValueConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture)
        {
            if (value is double sliderValue)
            {
                string? parameterString = parameter?.ToString();
                if (parameterString == "Text")
                {
                    if (sliderValue < 40)
                        return "Failed";
                    if (sliderValue < 80)
                        return "Passed";
                    return "Excellent";
                }
                else if (parameterString == "Color")
                {
                    if (sliderValue < 40)
                        return Colors.Red;
                    if (sliderValue < 80)
                        return Colors.Black;
                    return Colors.Green;
                }
            }
            return null;

        }
        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }

    }
}
