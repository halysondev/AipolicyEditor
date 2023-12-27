using System.Text;

namespace KuklusDataEditor
{
    public static class StaticConverter
    {
        public static int ToInt32(this string value) => int.Parse(value);
        public static int ToInt32(this object value) => int.Parse(value.ToString());
        public static uint ToUInt32(this string value) => uint.Parse(value);
        public static uint ToUInt32(this object value) => uint.Parse(value.ToString());
        public static string ToGBK(this byte[] value) => Encoding.GetEncoding("GBK").GetString(value);
        public static string ToUnicode(this byte[] value) => Encoding.Unicode.GetString(value);
        public static bool ToBool(this string value) => value.ToLower() == "true" ? true : false;

        public static string ToBase64(this string text) => System.Convert.ToBase64String(Encoding.Unicode.GetBytes(text));
        public static string FromBase64(this string text) => Encoding.Unicode.GetString(System.Convert.FromBase64String(text));
    }
}
