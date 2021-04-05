using NLog;
using PrintSample.Main.Commands;
using PrintSample.Main.Properties;

namespace PrintSample.Main
{
    public class MainViewModel
    {
        public LoadCommand Load { get; set; } = new LoadCommand();
        public PrintCommand Print { get; set; }
        public FileTypes FileTypes { get; set; }

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public MainViewModel()
        {
            this.Print = new PrintCommand();
            this.FileTypes = new FileTypes();
            this.Print.PrintAction += () => {
                logger.Debug(FileTypes.SelectedFileType);
            };
        }
    }
}