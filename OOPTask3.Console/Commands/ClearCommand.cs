using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class ClearCommand : SimpleConsoleCommand
{
    protected override string[] _inputVarieties { get; } =
    [
        "clear"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        System.Console.Clear();
    }
}