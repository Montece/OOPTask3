using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class StartGameCommand : SimpleConsoleCommand
{
    public StartGameCommand(int? shortcutNumber = null) : base(shortcutNumber)
    {
    }

    protected override string[] InputVarieties { get; } =
    [
        "start",
        "start game"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        context.ConsoleLayout?.LayoutManager.ShowLayout("Game");
    }
}