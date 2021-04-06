using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrintSample.Main.Properties
{
    public class SelectedFile: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string filePath = "";
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
                OnPropertyChanged("FilePath");
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}