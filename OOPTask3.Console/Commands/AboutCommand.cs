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

    protected override string[] InputVarieties { get; } =
    [
        "about"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        if (context.ConsoleLayout is null)
        {
            return;
        }

        context.ConsoleLayout.LayoutManager.ShowLayout("About");
    }
}