using OOPTask3.Game;

namespace OOPTask3.Console.Layout.Context;

public sealed class GameLayoutContext : ConsoleLayoutContext
{
    public GameLogic? GameLogic { get; set; }
}