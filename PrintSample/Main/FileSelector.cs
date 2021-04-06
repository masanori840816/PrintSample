using System;
using Microsoft.Win32;
using NLog;

namespace PrintSample.Main
{
    public class FileSelector
    {
        public Action<string>? FileSelected;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public void Open(string filter)
        {
            if(string.IsNullOrEmpty(filter))
            {
                logger.Warn("No File Type Selected");
                return;
            }
            var dialog = new OpenFileDialog();
            dialog.Title = "Open File";
            dialog.Filter = filter;
            if (dialog.ShowDialog() == true)
            {
                FileSelected?.Invoke(dialog.FileName);
            }
            else
            {
                logger.Debug("Canceled");
            }
        }
    }
}