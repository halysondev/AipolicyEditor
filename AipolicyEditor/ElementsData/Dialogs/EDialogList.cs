using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuklusDataEditor.Core.Dialogs
{
    public class EDialogList
    {
        public List<EDialog> Dialogs { get; set; }

        public EDialogList()
        {
            Dialogs = new List<EDialog>();
        }

        public void Load(BinaryReader br)
        {
            int count = br.ReadInt32();
            for (int i = 0; i < count; ++i)
            {
                EDialog ed = new EDialog
                {
                    TalkID = br.ReadInt32(),
                    Name = br.ReadBytes(128).ToUnicode()
                };
                int wcount = br.ReadInt32();
                for (int j = 0; j < wcount; ++j)
                {
                    EDialogWindow ewin = new EDialogWindow
                    {
                        ID = br.ReadInt32(),
                        ParentID = br.ReadInt32()
                    };
                    int text_len = br.ReadInt32();
                    ewin.Text = br.ReadBytes(text_len * 2).ToUnicode();
                    int ocount = br.ReadInt32();
                    for (int k = 0; k < ocount; ++k)
                    {
                        ewin.Options.Add(new EDialogOption
                        {
                            ID = br.ReadInt32(),
                            Text = br.ReadBytes(132).ToUnicode()
                        });
                    }
                    ed.Windows.Add(ewin);
                }
                Dialogs.Add(ed);
            }
        }

        public void Save()
        {

        }
    }
}
