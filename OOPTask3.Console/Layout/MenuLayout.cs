using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public sealed class MenuLayout : ConsoleLayout
{
    public override string ID => "Menu";
    public override ConsoleLayoutContext Context { get; } = new GameLayoutContext();
    public override ConsoleCommandsManager CommandsManager => new(
    [
        new ExitCommand(QUIT_SHORTCUT),
    ]);

    private const uint START_GAME_SHORTCUT = 1;
    private const uint ABOUT_SHORTCUT = 2;
    private const uint QUIT_SHORTCUT = 3;

    public override void Show()
    {
        System.Console.Clear();
        System.Console.WriteLine("=== Minesweeper ===");
        System.Console.WriteLine($"{START_GAME_SHORTCUT}. Start Game");
        System.Console.WriteLine($"{ABOUT_SHORTCUT}. About");
        System.Console.WriteLine($"{QUIT_SHORTCUT}. Quit");
    }

    public override void ProvideInput(string input)
    {
        var executeResult = CommandsManager.TryExecute(Context, input);

        switch (input)
        {

        }
    }
}
