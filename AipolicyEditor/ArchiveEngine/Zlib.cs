using System;
using System.IO;
using zlib;

namespace AngelicaArchiveManager.Core
{
    public class Zlib
    {
        public static byte[] Decompress(byte[] bytes, int size)
        {
            byte[] output = new byte[size];
            ZOutputStream zos = new ZOutputStream(new MemoryStream(output));
            try
            {
                CopyStream(new MemoryStream(bytes), zos, size);
            }
            catch (ZStreamException e)
            {
                Console.WriteLine($"Bad zlib data: {e.Message}");
            }
            return output;
        }

        public static byte[] Compress(byte[] bytes, int compression_level)
        {
            MemoryStream ms = new MemoryStream();
            ZOutputStream zos = new ZOutputStream(ms, compression_level);
            CopyStream(new MemoryStream(bytes), zos, bytes.Length);
            zos.finish();
            return ms.ToArray().Length < bytes.Length ? ms.ToArray() : bytes;
        }

        public static void CopyStream(Stream input, Stream output, int Size)
        {
            byte[] buffer = new byte[Size];
            int len;
            while ((len = input.Read(buffer, 0, Size)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }
    }
}