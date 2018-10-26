namespace Ericrypter.Commands
{
    using System;
    using System.Windows.Input;

    public class CriptografiaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action _execute;

        public CriptografiaCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
