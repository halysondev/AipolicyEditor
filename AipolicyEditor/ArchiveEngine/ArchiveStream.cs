using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AngelicaArchiveManager.Core.ArchiveEngine
{
    public class ArchiveStream : IDisposable
    {
        protected BufferedStream pck = null;
        protected BufferedStream pkx = null;
        private string path = "";
        public long Position = 0;
        const uint PCK_MAX_SIZE = 2147483392;
        const int BUFFER_SIZE = 16777216; // 33554432

        public ArchiveStream(string path)
        {
            this.path = path;
        }

        public void Reopen(bool ro)
        {
            Close();
            pck = OpenStream(path, ro);
            if (File.Exists(path.Replace(".pck", ".pkx")) && Path.GetExtension(path) != ".cup")
                pkx = OpenStream(path.Replace(".pck", ".pkx"), ro);
        }

        private BufferedStream OpenStream(string path, bool ro = true)
        {
            FileAccess fa = ro ? FileAccess.Read : FileAccess.ReadWrite;
            FileShare fs = ro ? FileShare.Read : FileShare.ReadWrite;
            return new BufferedStream(new FileStream(path, FileMode.OpenOrCreate, fa, fs), BUFFER_SIZE);
        }

        public void Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.Current:
                    Position += offset;
                    break;
                case SeekOrigin.End:
                    Position = GetLenght() + offset;
                    break;
            }
            if (Position <= pck.Length)
                pck.Seek(Position, SeekOrigin.Begin);
            else
                pkx.Seek(Position - pck.Length, SeekOrigin.Begin);
        }

        public long GetLenght() => pkx != null ? pck.Length + pkx.Length : pck.Length;

        public void Cut(long len)
        {
            if (len < PCK_MAX_SIZE)
            {
                pck.SetLength(len);
            }
            else
            {
                pkx.SetLength(PCK_MAX_SIZE - len);
            }
        }

        public byte[] ReadBytes(int count)
        {
            byte[] array = new byte[count];
            int BytesRead = 0;
            if (Position < pck.Length)
            {
                BytesRead = pck.Read(array, 0, count);
                if (BytesRead < count && pkx != null)
                {
                    pkx.Seek(0, SeekOrigin.Begin);
                    BytesRead += pkx.Read(array, BytesRead, count - BytesRead);
                }
            }
            else if (Position > pck.Length && pkx != null)
            {
                pkx.Read(array, 0, count);
            }
            Position += count;
            return array;
        }

        public void WriteBytes(byte[] array)
        {
            if (Position + array.Length < PCK_MAX_SIZE)
            {
                pck.Write(array, 0, array.Length);
            }
            else if (Position + array.Length > PCK_MAX_SIZE)
            {
                if (pkx == null)
                {
                    pkx = OpenStream(path.Replace(".pck", ".pkx"), false);
                }
                if (Position > PCK_MAX_SIZE)
                {
                    pkx.Write(array, 0, array.Length);
                }
                else
                {
                    pck.Write(array, 0, (int)(PCK_MAX_SIZE - Position));
                    pkx.Write(array, (int)(PCK_MAX_SIZE - Position), array.Length - (int)(PCK_MAX_SIZE - Position));
                }
            }
            Position += array.Length;
        }

        public short ReadInt16() => BitConverter.ToInt16(ReadBytes(2), 0);
        public ushort ReadUInt16() => BitConverter.ToUInt16(ReadBytes(2), 0);
        public int ReadInt32() => BitConverter.ToInt32(ReadBytes(4), 0);
        public uint ReadUInt32() => BitConverter.ToUInt32(ReadBytes(4), 0);
        public long ReadInt64() => BitConverter.ToInt64(ReadBytes(8), 0);
        public ulong ReadUInt64() => BitConverter.ToUInt64(ReadBytes(8), 0);

        public void WriteInt16(short value) => WriteBytes(BitConverter.GetBytes(value));
        public void WriteUInt16(ushort value) => WriteBytes(BitConverter.GetBytes(value));
        public void WriteInt32(int value) => WriteBytes(BitConverter.GetBytes(value));
        public void WriteUInt32(uint value) => WriteBytes(BitConverter.GetBytes(value));
        public void WriteInt64(long value) => WriteBytes(BitConverter.GetBytes(value));
        public void WriteUInt64(ulong value) => WriteBytes(BitConverter.GetBytes(value));

        public void Dispose()
        {
            pck?.Close();
            pkx?.Close();
        }

        public void Close()
        {
            pck?.Close();
            pkx?.Close();
        }
    }
}