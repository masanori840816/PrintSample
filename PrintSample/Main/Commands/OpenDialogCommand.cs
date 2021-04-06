using System;
using System.Windows.Input;
using NLog;

namespace PrintSample.Main.Commands
{
    public class OpenDialogCommand: ICommand
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public event EventHandler? CanExecuteChanged;

        public Action? Action;
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Action?.Invoke();
        }
    }
}