using AipolicyEditor;
using AngelicaArchiveManager.Interfaces;
using System.IO;

namespace AngelicaArchiveManager.Core.ArchiveEngine
{
    public class ArchiveEntryV2 : IArchiveEntry
    {
        public string Path { get; set; }
        public long Offset { get; set; }
        public int Size { get; set; }
        public int CSize { get; set; }

        public ArchiveEntryV2()
        {

        }

        public ArchiveEntryV2(byte[] data)
        {
            Read(data);
        }

        public void Read(byte[] data)
        {
            if (data.Length < 276)
                data = Zlib.Decompress(data, 276);
            BinaryReader br = new BinaryReader(new MemoryStream(data));
            Path = br.ReadBytes(260).ToGBK().Replace("/", "\\");
            Offset = br.ReadUInt32();
            Size = br.ReadInt32();
            CSize = br.ReadInt32();
            br.Close();
        }

        public byte[] Write(int cl)
        {
            return null;
        }
    }
}
