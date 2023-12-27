using Syncfusion.Windows.PropertyGrid;
using System;
using System.ComponentModel;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    [TypeConverter(typeof(ExpandableObjects))]
    public interface IOperation
    {
        int FromVersion { get; }
        int OperID { get; }
        string Name { get; }

        void Read(BinaryReader br);
        void Write(BinaryWriter bw);
        bool Search(string str);
    }
}
