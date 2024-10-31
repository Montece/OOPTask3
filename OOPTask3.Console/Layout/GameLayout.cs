using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.CellStateViews;
using OOPTask3.Console.Layout.Context;
using OOPTask3.Console.Layout.GameStateViews;
using OOPTask3.Game;
using OOPTask3.Random;

namespace OOPTask3.Console.Layout;

public sealed class GameLayout(LayoutManager layoutManager) : ConsoleLayout(layoutManager)
{
    public override string Id => "Game";
    protected override ConsoleLayoutContext Context { get; } = new GameLayoutContext();

    protected override ConsoleCommandsManager CommandsManager { get; } = new
    ([
        new OpenCellCommand(),
        new ToggleCellCommand(),
        new RestartGameCommand(RESTART_GAME_SHORTCUT),
        new MenuCommand(MENU_SHORTCUT),
    ]);

    private const int RESTART_GAME_SHORTCUT = 1;
    private const int MENU_SHORTCUT = 2;

    protected override void ShowImpl()
    {
        if (Context is not GameLayoutContext gameContext)
        {
            throw new WrongContextException();
        }

        System.Console.WriteLine("-. Open Cell <x> <y>");
        System.Console.WriteLine("-. Toggle Cell <x> <y>");
        System.Console.WriteLine($"{RESTART_GAME_SHORTCUT}. Restart Game");
        System.Console.WriteLine($"{MENU_SHORTCUT}. Back");
        System.Console.WriteLine();
        System.Console.WriteLine("===================");
        System.Console.WriteLine();

        if (gameContext.GameLogic == null)
        {
            PrepareGame();
        }

        gameContext.GameLogic?.Render();
    }

    protected override void HideImpl()
    {
        if (Context is not GameLayoutContext)
        {
            throw new WrongContextException();
        }
    }

    private void PrepareGame()
    {
        var gameLogic = GetGameLogic();

        if (gameLogic is not null)
        {
            return;
        }
        
        gameLogic = new(new StandardRandomGenerator(),
            [
                new NotStartedGameStateView(),
                new RunningGameStateView(),
                new WinGameStateView(),
                new LoseGameStateView()
            ],
            [
                new ClearCellStateView(),
                new FlagCellStateView(),
                new OpenedCellStateView(),
                new QuestionCellStateView(),
            ]);

        gameLogic.Start(9, 9, 10);

        SetGameLogic(gameLogic);
    }

    private GameLogic? GetGameLogic()
    {
        if (Context is not GameLayoutContext gameContext)
        {
            throw new WrongContextException();
        }

        return gameContext.GameLogic;
    }

    private void SetGameLogic(GameLogic gameLogic)
    {
        if (Context is not GameLayoutContext gameContext)
        {
            throw new WrongContextException();
        }

        gameContext.GameLogic = gameLogic;
    }

    protected override bool ProvideInputImpl(string input)
    {
        return false;
    }
}
