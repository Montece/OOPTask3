using OOPTask3.Console.Layout.Context;
using OOPTask3.Game.States;

namespace OOPTask3.Console.Commands;

public sealed class ToggleCellCommand(int? shortcutNumber = null) : ConsoleCommand(shortcutNumber)
{
    protected override bool IsMatchInternal(string input)
    {
        return input.StartsWith("toggle cell ", StringComparison.CurrentCultureIgnoreCase);
    }

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        var parameters = input.Replace("toggle cell ", string.Empty, StringComparison.CurrentCultureIgnoreCase).Split(' ');

        if (context is not GameLayoutContext gameContext ||
            gameContext.GameLogic?.CurrentState is not RunningGameState running || parameters.Length != 2 ||
            !int.TryParse(parameters[0], out var x) || !int.TryParse(parameters[1], out var y))
        {
            return;
        }

        running.ChangeCellSecondaryState(new(x, y));
        gameContext.GameLogic.CheckEnd();
        gameContext.ConsoleLayout?.ReShow();
    }
}