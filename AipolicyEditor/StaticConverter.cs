using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace AipolicyEditor
{
    public static class StaticConverter
    {
        public static int ToInt32(this string value)
        {
            return int.Parse(value);
        }

        public static string ToGBK(this byte[] value)
        {
            return Encoding.GetEncoding(936).GetString(value).Split('\0')[0];
        }

        public static string ToUnicode(this byte[] value)
        {
            return Encoding.Unicode.GetString(value).Split('\0')[0];
        }

        public static byte[] FromGBK(this string value, int len)
        {
            value += '\0';
            byte[] data = new byte[len];
            Encoding e = Encoding.GetEncoding(936);
            if (e.GetByteCount(value) > len)
            {
                Array.Copy(e.GetBytes(value), 0, data, 0, len);
            }
            else
            {
                Array.Copy(e.GetBytes(value), data, e.GetByteCount(value));
            }
            return data;
        }

        public static byte[] FromUnicode(this string value, int len)
        {
            value += '\0';
            byte[] data = new byte[len];
            Encoding e = Encoding.Unicode;
            if (e.GetByteCount(value) > len)
            {
                Array.Copy(e.GetBytes(value), 0, data, 0, len);
            }
            else
            {
                Array.Copy(e.GetBytes(value), data, e.GetByteCount(value));
            }
            return data;
        }
    }

    public class StringFormatToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                if (value.ToString().Contains(",") || value.ToString().Contains("."))
                    return float.TryParse(value.ToString(), out float number) ? number : 0;
                else
                    return int.TryParse(value.ToString(), out int number) ? number : 0;
            }
            else
            {
                return value;
            }
        }
    }

    public class EnumUIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            uint returnValue = 0;
            if (parameter is Type)
            {
                returnValue = (uint)Enum.Parse((Type)parameter, value.ToString());
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum enumValue = default(Enum);
            if (parameter is Type)
            {
                enumValue = (Enum)Enum.Parse((Type)parameter, value.ToString());
            }
            return enumValue;
        }
    }

    public class OperationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return $"[{values[0]}] {values[1]} ({MainWindow.Provider.GetLocalizedString("Version")} {values[2]})";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[0];
        }
    }
}
