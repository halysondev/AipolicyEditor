using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AipolicyEditor.ElementsData.Dialogs
{
    public class EDialog
    {
        public int TalkID { get; set; }
        public string Name { get; set; }
        public List<EDialogWindow> Windows { get; set; }

        public EDialog()
        {
            TalkID = 0;
            Name = "";
            Windows = new List<EDialogWindow>();
        }
    }
}
