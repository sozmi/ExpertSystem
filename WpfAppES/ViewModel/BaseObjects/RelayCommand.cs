﻿using System.Windows.Input;

namespace WpfAppES.ViewModel.BaseObjects
{
    /// <summary>
    /// Класс-обертка над командой
    /// </summary>
    /// <param name="execute">функция которую нужно выполнить</param>
    /// <param name="canExecute">функция которая проверяет необходимость выполнения</param>
    public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
    {
        private readonly Action<object?>? execute = execute;
        private readonly Func<object?, bool>? canExecute = canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (execute == null)
                return;
            execute(parameter);
        }
    }
}

