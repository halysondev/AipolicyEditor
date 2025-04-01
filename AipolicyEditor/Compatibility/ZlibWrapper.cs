using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Versioning;

namespace AipolicyEditor.Compatibility
{
    /// <summary>
    /// Implementação moderna de compressão Zlib para substituir o zlib.net
    /// </summary>
    [SupportedOSPlatform("windows")]
    public static class ZlibWrapper
    {
        /// <summary>
        /// Comprime dados usando o algoritmo Deflate (compatível com zlib)
        /// </summary>
        /// <param name="inputData">Dados a serem comprimidos</param>
        /// <returns>Dados comprimidos</returns>
        public static byte[] Compress(byte[] inputData)
        {
            if (inputData == null || inputData.Length == 0)
                return Array.Empty<byte>();

            using (var outputStream = new MemoryStream())
            {
                using (var deflateStream = new DeflateStream(outputStream, CompressionMode.Compress, true))
                {
                    deflateStream.Write(inputData, 0, inputData.Length);
                }
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Comprime uma string usando o algoritmo Deflate
        /// </summary>
        /// <param name="inputString">String a ser comprimida</param>
        /// <returns>Dados comprimidos</returns>
        public static byte[] Compress(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return Array.Empty<byte>();

            byte[] inputData = System.Text.Encoding.UTF8.GetBytes(inputString);
            return Compress(inputData);
        }

        /// <summary>
        /// Descomprime dados que foram comprimidos com o algoritmo Deflate
        /// </summary>
        /// <param name="compressedData">Dados comprimidos</param>
        /// <returns>Dados descomprimidos</returns>
        public static byte[] Decompress(byte[] compressedData)
        {
            if (compressedData == null || compressedData.Length == 0)
                return Array.Empty<byte>();

            using (var inputStream = new MemoryStream(compressedData))
            using (var outputStream = new MemoryStream())
            {
                using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    deflateStream.CopyTo(outputStream);
                }
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Descomprime dados e retorna como string UTF-8
        /// </summary>
        /// <param name="compressedData">Dados comprimidos</param>
        /// <returns>String descomprimida</returns>
        public static string DecompressToString(byte[] compressedData)
        {
            byte[] decompressedData = Decompress(compressedData);
            return System.Text.Encoding.UTF8.GetString(decompressedData);
        }

        /// <summary>
        /// Comprime um arquivo
        /// </summary>
        /// <param name="inputPath">Caminho do arquivo a ser comprimido</param>
        /// <param name="outputPath">Caminho do arquivo comprimido resultante</param>
        public static void CompressFile(string inputPath, string outputPath)
        {
            using (var inputStream = File.OpenRead(inputPath))
            using (var outputStream = File.Create(outputPath))
            using (var deflateStream = new DeflateStream(outputStream, CompressionMode.Compress))
            {
                inputStream.CopyTo(deflateStream);
            }
        }

        /// <summary>
        /// Descomprime um arquivo
        /// </summary>
        /// <param name="compressedFilePath">Caminho do arquivo comprimido</param>
        /// <param name="decompressedFilePath">Caminho para salvar o arquivo descomprimido</param>
        public static void DecompressFile(string compressedFilePath, string decompressedFilePath)
        {
            using (var inputStream = File.OpenRead(compressedFilePath))
            using (var outputStream = File.Create(decompressedFilePath))
            using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                deflateStream.CopyTo(outputStream);
            }
        }
    }
} 