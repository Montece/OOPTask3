using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class MenuCommand : SimpleConsoleCommand
{
    public MenuCommand()
    {
    }

    public MenuCommand(int shortcutNumber) : base(shortcutNumber)
    {
    }

    protected override string[] InputVarieties { get; } =
    [
        "back"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        if (context.ConsoleLayout is null)
        {
            return;
        }

        context.ConsoleLayout.LayoutManager.ShowLayout("Menu");
    }
}