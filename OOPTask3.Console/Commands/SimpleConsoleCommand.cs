namespace OOPTask3.Console.Commands;

public abstract class SimpleConsoleCommand : ConsoleCommand
{
    protected abstract string[] InputVarieties { get; }

    protected SimpleConsoleCommand(int? shortcutNumber = null) : base(shortcutNumber)
    {
    }

    protected override bool IsMatchInternal(string input)
    {
        var lowerInput = input.ToLower();
        return InputVarieties.Any(v => v.ToLower().Equals(lowerInput));
    }
}