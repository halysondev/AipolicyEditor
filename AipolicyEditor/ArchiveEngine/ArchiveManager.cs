using AngelicaArchiveManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using AipolicyEditor;

namespace AngelicaArchiveManager.Core.ArchiveEngine
{
    public class ArchiveManager
    {
        private string Path { get; set; } = "";
        public List<IArchiveEntry> Files { get; set; } = new List<IArchiveEntry>();
        private ArchiveStream Stream { get; set; }
        private ArchiveKey Key { get; set; }
        public ArchiveVersion Version { get; set; }

        public ArchiveManager(string path, ArchiveKey key, bool detect_version = true)
        {
            Path = path;
            Key = key;
            Stream = new ArchiveStream(path);
            if (detect_version)
            {
                Stream.Reopen(true);
                Stream.Seek(-4, SeekOrigin.End);
                short version = Stream.ReadInt16();
                switch (version)
                {
                    case 2:
                        Version = ArchiveVersion.V2;
                        break;
                    case 3:
                        Version = ArchiveVersion.V3;
                        break;
                    default:
                        Utils.ShowMessage("Unknown archive type");
                        break;
                }
                Stream.Close();
            }
        }

        public void ReadFileTable()
        {
            switch (Version)
            {
                case ArchiveVersion.V2:
                    ReadFileTableV2();
                    break;
                case ArchiveVersion.V3:
                    ReadFileTableV3();
                    break;
                default:
                    Utils.ShowMessage("Unknown archive type");
                    break;
            }
        }

        #region V2
        public void ReadFileTableV2()
        {
            Stream.Reopen(true);
            Stream.Seek(-8, SeekOrigin.End);
            int FilesCount = Stream.ReadInt32();
            Stream.Seek(-272, SeekOrigin.End);
            long FileTableOffset = (long)((ulong)((uint)(Stream.ReadUInt32() ^ (ulong)Key.KEY_1)));
            Stream.Seek(FileTableOffset, SeekOrigin.Begin);
            BinaryReader TableStream = new BinaryReader(new MemoryStream(Stream.ReadBytes((int)(Stream.GetLenght() - FileTableOffset - 280))));
            for (int i = 0; i < FilesCount; ++i)
            {
                int EntrySize = TableStream.ReadInt32() ^ Key.KEY_1;
                TableStream.ReadInt32();
                Files.Add(new ArchiveEntryV2(TableStream.ReadBytes(EntrySize)));
            }
            Stream.Close();
        }
        #endregion

        #region V3
        public void ReadFileTableV3()
        {
            Stream.Reopen(true);
            Stream.Seek(-8, SeekOrigin.End);
            int FilesCount = Stream.ReadInt32();
            Stream.Seek(-280, SeekOrigin.End);
            long FileTableOffset = Stream.ReadInt64() ^ Key.KEY_1;
            Stream.Seek(FileTableOffset, SeekOrigin.Begin);
            BinaryReader TableStream = new BinaryReader(new MemoryStream(Stream.ReadBytes((int)(Stream.GetLenght() - FileTableOffset - 288))));
            for (int i = 0; i < FilesCount; ++i)
            {
                int EntrySize = TableStream.ReadInt32() ^ Key.KEY_1;
                TableStream.ReadInt32();
                Files.Add(new ArchiveEntryV3(TableStream.ReadBytes(EntrySize)));
            }
            Stream.Close();
        }
        #endregion

        public byte[] GetFile(IArchiveEntry entry, bool reload = true)
        {
            if (reload)
                Stream.Reopen(true);
            Stream.Seek(entry.Offset, SeekOrigin.Begin);
            byte[] file = Stream.ReadBytes(entry.CSize);
            if (entry.CSize < entry.Size)
                return Zlib.Decompress(file, entry.Size);
            else
                return file;
        }

        public List<byte[]> GetFiles(List<IArchiveEntry> files)
        {
            Stream.Reopen(true);
            List<byte[]> fs = new List<byte[]>();
            foreach (IArchiveEntry entry in files)
            {
                fs.Add(GetFile(entry, false));
            }
            Stream.Close();
            return fs;
        }
    }
}