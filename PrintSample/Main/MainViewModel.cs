using NLog;

namespace PrintSample.Main
{
    public class MainViewModel
    {
        public LoadCommand Load { get; set; } = new LoadCommand();

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
    }
}