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

    protected override string[] _inputVarieties { get; } =
    [
        "back"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        context.ConsoleLayout.LayoutManager.ShowLayout("Menu");
    }
}