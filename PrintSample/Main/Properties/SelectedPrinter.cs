using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;

namespace PrintSample.Main.Properties
{
    public class SelectedPrinter: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly string[] printerNames;
        public string[] PrinterNames => this.printerNames;
        private string printerName = "";
        public string PrinterName
        {
            get
            {
                return this.printerName;
            }
            set
            {
                this.printerName = value;
                OnPropertyChanged("PrinterName");
            }
        }
        public SelectedPrinter()
        {
            LocalPrintServer printServer = new LocalPrintServer();
            printerNames = printServer.GetPrintQueues()
                .Select(q => q.Name)
                .ToArray();
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}