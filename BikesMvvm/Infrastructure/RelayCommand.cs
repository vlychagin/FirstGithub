﻿using System.Windows.Input;

namespace BikesMvvm.Infrastructure;

public class RelayCommand(Action<object> execute, Func<object, bool> canExecute = null!)
    : ICommand
{
    public event EventHandler? CanExecuteChanged {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    } // CanExecuteChanged

    // RelayCommand

    public bool CanExecute(object? parameter) => canExecute == null! || canExecute(parameter!); // CanExecute

    public void Execute(object? parameter) => execute(parameter!);
} // class RelayCommand
