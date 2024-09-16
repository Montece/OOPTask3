using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class ToggleCellCommand : ConsoleCommand
{
    public ToggleCellCommand(int? shortcutNumber = null) : base(shortcutNumber)
    {
    }

    protected override bool IsMatchInternal(string input)
    {
        return input.ToLower().StartsWith("toggle cell ");
    }

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        var parameters = input.ToLower().Replace("toggle cell ", string.Empty).Split(' ');

        if (context is GameLayoutContext gameContext && parameters.Length == 2 && int.TryParse(parameters[0], out var x) && int.TryParse(parameters[1], out var y))
        {
            gameContext.GameLogic?.ChangeCellState(new(x, y));
            gameContext.ConsoleLayout?.Show();
        }
    }
}