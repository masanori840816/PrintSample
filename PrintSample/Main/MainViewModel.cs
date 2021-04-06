using System;
using NLog;
using PrintSample.Files;
using PrintSample.Main.Commands;
using PrintSample.Main.Properties;
using PrintSample.Pdf;

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
        private readonly IPdfLoader pdfLoader;
        public MainViewModel(IPdfLoader pdfLoader)
        {
            this.Open = new OpenDialogCommand();
            this.Print = new PrintCommand();
            this.FileTypes = new FileTypes();
            this.SelectedFile = new SelectedFile();
            this.SelectedPrinter = new SelectedPrinter();
            this.fileSelector = new FileSelector();
            this.pdfLoader = pdfLoader;
            this.Print.Action += async () =>
            {
                try
                {
                    var loadedImages = await this.pdfLoader.LoadAsync(
                        new LoadPdfFileArgs(this.SelectedFile.FilePath));
                    logger.Debug("Result: " + loadedImages.Count);
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message);
                }
                
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