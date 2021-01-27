using System;
using System.Windows.Input;
using Newtonsoft.Json;
using NLog;

namespace PrintSample.Main
{
    public class LoadCommand : ICommand
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public event EventHandler? CanExecuteChanged;

        //public Action<LoadSpreadsheetArgs>? LoadSpreadsheetNeeded;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            // ex. dotnet run spreadsheet "{'filePath':'sample.xlsx','sheetName':'Sheet1'}"
            var args = Environment.GetCommandLineArgs();
            if(args.Length <= 2)
            {
                logger.Error("No arguments");
                return;
            }
            switch(args[1])
            {
                case "pdf":
                    logger.Debug("Load PDF");
                    // TODO: add an action for loading PDF
                    break;
                case "spreadsheet":
                    logger.Debug("Load Spreadsheet");
                   // LoadSpreadsheetNeeded?.Invoke(
                     //   JsonConvert.DeserializeObject<LoadSpreadsheetArgs>(args[2]));
                    break;
                default:
                    logger.Error("No actions");
                    break;
            }
        }
    }
}