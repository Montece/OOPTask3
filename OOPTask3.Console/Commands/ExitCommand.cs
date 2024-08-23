using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

internal sealed class ExitCommand : SimpleConsoleCommand
{
    public ExitCommand() : base()
    {
    }

    public ExitCommand(uint shortcutNumber) : base(shortcutNumber)
    {
    }

    protected override string[] _inputVarieties { get; } = 
    [
        "exit",
        "quit",
        "stop",
        "close"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        Environment.Exit(0);
    }
}