using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class AboutCommand : SimpleConsoleCommand
{
    public AboutCommand()
    {
    }

    public AboutCommand(int? shortcutNumber) : base(shortcutNumber)
    {
    }

    protected override string[] _inputVarieties { get; } =
    [
        "about"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        context.ConsoleLayout.LayoutManager.ShowLayout("About");
    }
}