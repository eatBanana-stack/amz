using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AmazonTools.Desktop
{
    public class ButtonStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 判断是否有值
            bool hasValue = !string.IsNullOrEmpty(value?.ToString());

            // 通过parameter区分是转换背景色还是内容文本
            if (parameter?.ToString() == "Background")
            {
                return hasValue ? Brushes.Green : Brushes.Red;
            }
            else
            {
                return hasValue ? "查看" : "绑定";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
