using AipolicyEditor.AIPolicy.Operations.CustomEditors;
using System.IO;

namespace AipolicyEditor.AIPolicy
{
    public class POLICY_ZONE_VERT
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public POLICY_ZONE_VERT() { }
        public POLICY_ZONE_VERT(BinaryReader br)
        {
            X = br.ReadSingle();
            Y = br.ReadSingle();
            Z = br.ReadSingle();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(X);
            bw.Write(Y);
            bw.Write(Z);
        }
    }
}
