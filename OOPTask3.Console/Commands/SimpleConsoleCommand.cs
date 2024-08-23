namespace OOPTask3.Console.Commands;

internal abstract class SimpleConsoleCommand : ConsoleCommand
{
    protected abstract string[] _inputVarieties { get; }
    private string? _shortcutNumber = null;

    public SimpleConsoleCommand()
    {

    }

    public SimpleConsoleCommand(uint shortcutNumber)
    {
        _shortcutNumber = shortcutNumber.ToString();
    }

    public override bool IsMatch(string input)
    {
        var lowerInput = input.ToLower();
        return _inputVarieties.Any(v => v.ToLower().Equals(lowerInput)) || !string.IsNullOrEmpty(_shortcutNumber) && _shortcutNumber.Equals(lowerInput);
    }
}