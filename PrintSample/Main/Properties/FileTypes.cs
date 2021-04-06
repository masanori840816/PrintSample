using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrintSample.Main.Properties
{
    public class FileTypes: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<string> Types => new List<string>
        {
            "PDF"
        };
        private string selectedFileType = "";
        public string SelectedFileType
        {
            get
            {
                return this.selectedFileType;
            }
            set
            {
                this.selectedFileType = value;
                OnPropertyChanged("SelectedFileType");
            }
        }
        public string GetFilter(string key)
        {
            switch(key)
            {
                case "PDF":
                    return "PDFファイル(*.pdf)|*.pdf";
                default:
                    return "";
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}