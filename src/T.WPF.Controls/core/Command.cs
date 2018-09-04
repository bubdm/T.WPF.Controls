using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using T.Controls.Extensions;

namespace T.Controls.core
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Func<bool> _canExcute = () => true;

        private Action _excute;

        public Command(Action excute, Func<bool> canExcute)
        {
            _canExcute = canExcute;
            _excute = excute;
        }

        public Command(Action excute)
        {
            _excute = excute;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExcute != null)
            {
                return _canExcute();
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if(_excute != null)
            {
                _excute();
            }
        }
    }


    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Func<T,bool> _canExcute = (args) => true;

        private Action<T> _excute;

        public Command(Action<T> excute, Func<T, bool> canExcute)
        {
            _canExcute = canExcute;
            _excute = excute;
        }

        public Command(Action<T> excute)
        {
            _excute = excute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExcute != null)
            {
                return _canExcute(ConverterHelper.SafeCast<T>(parameter));
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if (_excute != null)
            {
                _excute(ConverterHelper.SafeCast<T>(parameter));
            }
        }
    }
}
