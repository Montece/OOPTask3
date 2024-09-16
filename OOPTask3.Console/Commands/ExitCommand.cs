using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class ExitCommand : SimpleConsoleCommand
{
    public ExitCommand()
    {
    }

    public ExitCommand(int shortcutNumber) : base(shortcutNumber)
    {
    }

    protected override string[] InputVarieties { get; } = 
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