using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

internal sealed class HiCommand : SimpleConsoleCommand
{
    protected override string[] _inputVarieties { get; } =
    [
        "hi"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        System.Console.WriteLine("hi");
    }
}