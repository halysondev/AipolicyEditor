using AipolicyEditor;
using AngelicaArchiveManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AngelicaArchiveManager.Core.ArchiveEngine
{
    public class ArchiveEntryV3 : IArchiveEntry
    {
        public string Path { get; set; }
        public long Offset { get; set; }
        public int Size { get; set; }
        public int CSize { get; set; }

        public ArchiveEntryV3()
        {

        }

        public ArchiveEntryV3(byte[] data)
        {
            Read(data);
        }

        public void Read(byte[] data)
        {
            if (data.Length < 288)
                data = Zlib.Decompress(data, 288);
            BinaryReader br = new BinaryReader(new MemoryStream(data));
            Path = br.ReadBytes(260).ToGBK().Replace("/", "\\");
            br.ReadInt32();
            Offset = br.ReadInt64();
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
