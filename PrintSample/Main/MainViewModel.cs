using NLog;
using PrintSample.Main.Commands;
using PrintSample.Main.Properties;

namespace PrintSample.Main
{
    public class MainViewModel
    {
        public LoadCommand Load => new LoadCommand();
        public OpenDialogCommand Open { get; }
        public PrintCommand Print { get; }
        public FileTypes FileTypes { get; set; }
        public SelectedFile SelectedFile { get; set; }
        public SelectedPrinter SelectedPrinter { get; set; }
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly FileSelector fileSelector;
        public MainViewModel()
        {
            this.Open = new OpenDialogCommand();
            this.Print = new PrintCommand();
            this.FileTypes = new FileTypes();
            this.SelectedFile = new SelectedFile();
            this.SelectedPrinter = new SelectedPrinter();
            this.fileSelector = new FileSelector();
            this.Print.Action += () =>
            {
                logger.Debug(this.SelectedPrinter.PrinterName);
            };
            this.fileSelector.FileSelected += (filePath) =>
            {
                this.SelectedFile.FilePath = filePath;
            };
            this.Open.Action += () =>
            {
                fileSelector.Open(this.FileTypes.GetFilter(this.FileTypes.SelectedFileType));
            };
        }
    }
}