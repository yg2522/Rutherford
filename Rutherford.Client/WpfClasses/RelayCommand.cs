using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rutherford.Client.WpfClasses
{
    /// <summary>
    /// basic implementation of ICommand for use in WPF MVVM binding
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, null);
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            if(_execute != null)
                _execute(parameter);
        }
    }
}
