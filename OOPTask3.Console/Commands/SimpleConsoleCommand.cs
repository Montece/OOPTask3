namespace OOPTask3.Console.Commands;

public abstract class SimpleConsoleCommand : ConsoleCommand
{
    protected abstract string[] _inputVarieties { get; }

    protected SimpleConsoleCommand(int? shortcutNumber = null) : base(shortcutNumber)
    {
    }

    protected override bool IsMatchInternal(string input)
    {
        var lowerInput = input.ToLower();
        return _inputVarieties.Any(v => v.ToLower().Equals(lowerInput));
    }
}