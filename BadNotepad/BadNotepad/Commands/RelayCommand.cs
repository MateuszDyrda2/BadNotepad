using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BadNotepad.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> m_execute;
        readonly Predicate<object> m_canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) {}

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            m_execute = execute;
            m_canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return m_canExecute == null ? true : m_canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) { m_execute(parameter); }
    }
}
