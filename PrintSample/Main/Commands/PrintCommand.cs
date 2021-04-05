using System;
using System.Windows.Input;
using NLog;

namespace PrintSample.Main.Commands
{
    public class PrintCommand: ICommand
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public event EventHandler? CanExecuteChanged;

        public Action? PrintAction;
        
        public bool CanExecute(object? parameter)
        {
            // TODO: 入力必須項目が入ってなければfalseに
            return true;
        }

        public void Execute(object? parameter)
        {
            PrintAction?.Invoke();
        }
    }
}