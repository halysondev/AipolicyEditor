using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AipolicyEditor.AIPolicy
{
    public class GLOBAL_HELPER
    {
        private static object p_ModifeListLocker = new object();
        private static List<ModifeData> p_ModifeList = new List<ModifeData>();

        public static string FilePath;

        public static void AddModife(long position, byte[] bytes)
        {
            lock (p_ModifeListLocker)
            {
                p_ModifeList.Add(new ModifeData
                {
                    Address = position,
                    Bytes = bytes,
                });
            }
        }

        public static void ProcessModife()
        {
            if (string.IsNullOrEmpty(FilePath))
                return;

            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Write))
            {
                lock (p_ModifeListLocker)
                {
                    foreach (var modife in p_ModifeList)
                    {
                        stream.Position = modife.Address;
                        stream.Write(modife.Bytes, 0, modife.Bytes.Length);
                    }
                }
            }
        }
    }

    public class ModifeData
    {
        public long Address { get; set; }
        public byte[] Bytes { get; set; }
    }
}