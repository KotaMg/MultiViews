using System;
using System.Windows.Input;

namespace MultiViews.Core
{
    class RelayCommand : Icommand 
    {
        private Action<object> _exexute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _exexute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object paramater)
        {
            _exexute(paramater);
        }


    }
}
