using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class HiCommand : SimpleConsoleCommand
{
    protected override string[] InputVarieties { get; } =
    [
        "hi"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        System.Console.WriteLine("hi");
    }
}