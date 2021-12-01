using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VideoTagPlayer.Main.utility
{
    public class Command : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;

        public Command(Action<object> execute)
        {
            _execute = execute;
        }


        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
            //if (_canExecute != null)
            //{
            //    return true;//_canExecute(parameter);
            //}
            //else
            //{
            //    return false;
            //}
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
