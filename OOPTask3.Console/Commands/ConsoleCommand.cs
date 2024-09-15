using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public abstract class ConsoleCommand : IConsoleCommand
{
    private string? _shortcutNumber = null;

    protected ConsoleCommand(int? shortcutNumber = null)
    {
        _shortcutNumber = shortcutNumber?.ToString();
    }

    public bool IsMatch(string input)
    {
        return !string.IsNullOrEmpty(_shortcutNumber) && _shortcutNumber.Equals(input) || IsMatchInternal(input);
    }

    protected abstract bool IsMatchInternal(string input);

    public void Execute(ConsoleLayoutContext context, string input)
    {
        if (!IsMatch(input))
        {
            return;
        }

        ExecuteInternal(context, input);
    }

    protected abstract void ExecuteInternal(ConsoleLayoutContext context, string input);
}