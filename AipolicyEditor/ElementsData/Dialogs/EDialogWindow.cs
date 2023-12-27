using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KuklusDataEditor.Core.Dialogs
{
    public class EDialogWindow
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Text { get; set; }
        public List<EDialogOption> Options { get; set; }

        public EDialogWindow()
        {
            ID = 0;
            ParentID = 0;
            Text = "";
            Options = new List<EDialogOption>();
        }
    }
}
