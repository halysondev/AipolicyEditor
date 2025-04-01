using System;
using System.IO;
using AipolicyEditor.Compatibility;

namespace AngelicaArchiveManager.Core
{
    public class Zlib
    {
        public static byte[] Decompress(byte[] bytes, int size)
        {
            try
            {
                // Usa a implementação moderna de Zlib
                return ZlibWrapper.Decompress(bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Bad zlib data: {e.Message}");
                // Retorna um array vazio em caso de erro
                return new byte[size];
            }
        }

        public static byte[] Compress(byte[] bytes, int compression_level)
        {
            // Usa a implementação moderna de Zlib
            byte[] compressed = ZlibWrapper.Compress(bytes);
            
            // Retorna os dados originais se a compressão não resultar em economia de espaço
            return compressed.Length < bytes.Length ? compressed : bytes;
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