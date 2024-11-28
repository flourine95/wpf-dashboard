using System.Diagnostics;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Func<object, Task> _executeAsync;
    private readonly Predicate<object> _canExecute;

    public RelayCommand(Func<object, Task> executeAsync, Predicate<object> canExecute = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        bool result = _canExecute?.Invoke(parameter) ?? true;
        return result;
    }

    public async void Execute(object parameter)
    {
        if (CanExecute(parameter))
        {
            await _executeAsync(parameter);
        }
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler CanExecuteChanged;
}