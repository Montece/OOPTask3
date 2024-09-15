using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;

namespace OOPTask3.Console.Layout;

public sealed class MenuLayout : ConsoleLayout
{
    public override string ID => "Menu";
    public override ConsoleLayoutContext Context { get; } = new ConsoleLayoutContext();
    public override ConsoleCommandsManager CommandsManager { get; } = new(
    [
        new StartGameCommand(START_GAME_SHORTCUT),
        new AboutCommand(ABOUT_SHORTCUT),
        new ExitCommand(QUIT_SHORTCUT),
    ]);

    private const int START_GAME_SHORTCUT = 1;
    private const int ABOUT_SHORTCUT = 2;
    private const int QUIT_SHORTCUT = 3;

    public MenuLayout(LayoutManager layoutManager) : base(layoutManager)
    {
    }

    protected override void ShowImpl()
    {
        System.Console.WriteLine($"{START_GAME_SHORTCUT}. Start Game");
        System.Console.WriteLine($"{ABOUT_SHORTCUT}. About");
        System.Console.WriteLine($"{QUIT_SHORTCUT}. Quit");
    }

    protected override void HideImpl()
    {
    }

    protected override void ProvideInputImpl(string input)
    {
        switch (input)
        {

        }
    }
}
