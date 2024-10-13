using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Commands;

public sealed class OpenCellCommand(int? shortcutNumber = null) : ConsoleCommand(shortcutNumber)
{
    protected override bool IsMatchInternal(string input)
    {
        return input.ToLower().StartsWith("open cell ");
    }

    protected override void ExecuteInternal(ConsoleLayoutContext context, string input)
    {
        var parameters = input.ToLower().Replace("open cell ", string.Empty).Split(' ');

        if (context is GameLayoutContext gameContext && parameters.Length == 2 && int.TryParse(parameters[0], out var x) && int.TryParse(parameters[1], out var y))
        {
            //gameContext.GameLogic.CurrentState.ProvideInput...OpenCell(new(x, y));
            gameContext.ConsoleLayout?.Show();
        }
    }
}