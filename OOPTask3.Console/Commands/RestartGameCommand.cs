using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class RestartGameCommand : SimpleConsoleCommand
{
    public RestartGameCommand()
    {
    }

    public RestartGameCommand(int? shortcutNumber = null) : base(shortcutNumber)
    {
    }

    protected override string[] _inputVarieties { get; } =
    [
        "restart",
        "restart game",
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        if (context is GameLayoutContext gameContext)
        {
            gameContext.GameLogic = null;
        }
        
        context.ConsoleLayout.LayoutManager.ShowLayout("Game");
    }
}