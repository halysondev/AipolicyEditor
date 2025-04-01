using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using WPFLocalizeExtension.Extensions;

namespace AipolicyEditor.AIPolicy
{
    public partial class AIFile : INotifyPropertyChanged
    {
        private string path = "";
        public bool InAnotherThread = true;
        public byte[] Header { get; set; }
        private ObservableCollection<CPolicyData> _Controllers = new ObservableCollection<CPolicyData>();
        public ObservableCollection<CPolicyData> Controllers
        {
            get
            {
                return _Controllers;
            }
            set
            {
                if (_Controllers != value)
                {
                    _Controllers = value;
                    OnPropertyChanged("Controllers");
                }
            }
        }

        private int _ControllerIndex = -1;
        public int ControllerIndex
        {
            get
            {
                return _ControllerIndex;
            }
            set
            {
                if (_ControllerIndex != value)
                {
                    _ControllerIndex = value;
                    TriggerIndex = -1;
                    OperationIndex = -1;
                    OnPropertyChanged("ControllerIndex");
                    OnPropertyChanged("CurrentTriggers");
                    OnPropertyChanged("CurrentController");
                    OnPropertyChanged("TriggersHeader");
                    OnPropertyChanged("OperationsHeader");
                }
            }
        }

        private int _TriggerIndex = -1;
        public int TriggerIndex
        {
            get
            {
                return _TriggerIndex;
            }
            set
            {
                if (_TriggerIndex != value)
                {
                    _TriggerIndex = value;
                    OperationIndex = -1;
                    OnPropertyChanged("TriggerIndex");
                    OnPropertyChanged("CurrentTrigger");
                    OnPropertyChanged("CurrentOperations");
                    OnPropertyChanged("OperationsHeader");
                }
            }
        }

        private int _OperationIndex = -1;
        public int OperationIndex
        {
            get
            {
                return _OperationIndex;
            }
            set
            {
                if (_OperationIndex != value)
                {
                    _OperationIndex = value;
                    OnPropertyChanged("OperationIndex");
                    OnPropertyChanged("CurrentOperation");
                    OnPropertyChanged("OperationsHeader");
                }
            }
        }

        public CPolicyData CurrentController
        {
            get
            {
                if (ControllerIndex > -1)
                    return Controllers[ControllerIndex];
                else
                    return null;
            }
            set
            {
                if (ControllerIndex > -1 && Controllers[ControllerIndex] != value)
                    Controllers[ControllerIndex] = value;
            }
        }

        public ObservableCollection<CTriggerData> CurrentTriggers
        {
            get
            {
                if (ControllerIndex > -1)
                    return Controllers[ControllerIndex].Triggers;
                else
                    return null;
            }
            set
            {
                if (ControllerIndex > -1 && Controllers[ControllerIndex].Triggers != value)
                    Controllers[ControllerIndex].Triggers = value;
            }
        }

        public CTriggerData CurrentTrigger
        {
            get
            {
                if (ControllerIndex > -1 && TriggerIndex > -1)
                    return Controllers[ControllerIndex].Triggers[TriggerIndex];
                else
                    return null;
            }
            set
            {
                if (ControllerIndex > -1 && TriggerIndex > -1 && Controllers[ControllerIndex].Triggers[TriggerIndex] != value)
                    Controllers[ControllerIndex].Triggers[TriggerIndex] = value;
            }
        }

        public ObservableCollection<IOperation> CurrentOperations
        {
            get
            {
                if (ControllerIndex > -1 && TriggerIndex > -1)
                    return Controllers[ControllerIndex].Triggers[TriggerIndex].Operations;
                else
                    return null;
            }
            set
            {
                if (ControllerIndex > -1 && TriggerIndex > -1 && Controllers[ControllerIndex].Triggers[TriggerIndex].Operations != value)
                    Controllers[ControllerIndex].Triggers[TriggerIndex].Operations = value;
            }
        }

        public IOperation CurrentOperation
        {
            get
            {
                if (TriggerIndex > -1 && OperationIndex > -1)
                    return Controllers[ControllerIndex].Triggers[TriggerIndex].Operations[OperationIndex];
                else
                    return null;
            }
            set
            {
                if (TriggerIndex > -1 && OperationIndex > -1 && Controllers[ControllerIndex].Triggers[TriggerIndex].Operations[OperationIndex] != value)
                    Controllers[ControllerIndex].Triggers[TriggerIndex].Operations[OperationIndex] = value;
            }
        }

        // Flag to optimize context menu operations
        private bool _isSuspendingNotifications = false;

        public void Read(string path)
        {
            this.path = path;
            if (InAnotherThread)
                new Thread(() => _Read(path)).Start();
            else
                _Read(path);
        }

        private string ModifyFileName(string originalPath)
        {
            // Obter o diretório do caminho original
            string directory = Path.GetDirectoryName(originalPath);

            // Obter o nome do arquivo com extensão
            string fileNameWithExtension = Path.GetFileName(originalPath);
            /*
            // Verifique se o nome do arquivo é "aipolicy.data"
            if (fileNameWithExtension == "aipolicy.data")
            {
                // Mudar o nome do arquivo para "aipolicy_save.data"
                string newFileName = "aipolicy_save.data";

                // Combinar o novo caminho
                string newPath = Path.Combine(directory, newFileName);

                return newPath;
            }
            */

            string backupFileName = "aipolicy.data.bak";
            string backupPath = Path.Combine(directory, backupFileName);

            // Verifique se o arquivo de backup já existe
            if (File.Exists(backupPath))
            {
                // Se o arquivo de backup já existir, exclua-o
                File.Delete(backupPath);
            }

            // Renomear o arquivo original para o arquivo de backup
            File.Move(originalPath, backupPath);

            // Se o nome do arquivo não for o esperado, você pode retornar o original
            // ou lançar uma exceção, dependendo da lógica do seu programa.
            return originalPath;
        }

        public void Save()
        {
            string newPath = ModifyFileName(path);
            _Save(newPath);
        }

        public void SaveAs(string path)
        {
            _Save(path);
        }

        private void _Read(string path)
        {
            CPolicyData.MaxVersion = 0;
            CTriggerData.MaxVersion = 0;
            BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read));
            Header = br.ReadBytes(4);
            int count = br.ReadInt32();
            ObservableCollection<CPolicyData> data = new ObservableCollection<CPolicyData>();
            for (int i = 0; i < count; ++i)
            {
                CPolicyData cpd = new CPolicyData();
                cpd.Read(br);
                data.Add(cpd);
            }
            _Controllers = new ObservableCollection<CPolicyData>(data);
            br.Close();
            OnPropertyChanged("Controllers");
        }

        private void _Save(string path)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write));
            bw.Write(Header);
            bw.Write(Controllers.Count);
            for (int i = 0; i < Controllers.Count; ++i)
            {
                Controllers[i].Write(bw);
            }
            bw.Close();
            Utils.ShowMessage(MainWindow.Provider.GetLocalizedString("FileSaved"));
        }

        // Method to suspend property change notifications temporarily
        public void SuspendNotifications()
        {
            _isSuspendingNotifications = true;
        }

        // Method to resume property change notifications
        public void ResumeNotifications()
        {
            _isSuspendingNotifications = false;
            // Refresh the UI with a single notification
            OnPropertyChanged("CurrentOperation");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (!_isSuspendingNotifications && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
