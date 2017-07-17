using System;
using System.Windows.Input;
using SourceComparer.Abstract.Commands;

namespace SourceComparer.Commands
{
    public class NamedCommand : INamedCommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        public NamedCommand(Action<object> execute) : this(null, execute)
        {
        }

        public NamedCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
