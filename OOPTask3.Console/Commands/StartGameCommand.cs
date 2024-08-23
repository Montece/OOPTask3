using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

internal sealed class StartGameCommand : SimpleConsoleCommand
{
    protected override string[] _inputVarieties { get; } =
    [
        "start",
        "start game"
    ];

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        if (context is not GameLayoutContext gameContext)
        {
            return;
        }

        if (gameContext.GameLogic != null)
        {
            gameContext.GameLogic.Stop();
            gameContext.GameLogic = null;
        }

        gameContext.GameLogic = new GameLogic();
        gameContext.GameLogic.Start();
    }
}