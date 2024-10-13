using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;
using OOPTask3.Console.Layout.Views;
using OOPTask3.Game;
using OOPTask3.Game.Cells;
using OOPTask3.Game.Cells.States;
using OOPTask3.Game.States;
using OOPTask3.Random;
using OOPTask3.StateMachine;

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
            RenderMap();
        }

        gameContext.GameLogic.Render();

        /*else
        {
            switch (gameContext.GameLogic.State)
            {
                case GameState.NotStarted:
                    System.Console.WriteLine("Game is not running!");
                    break;
                case GameState.Running:
                    RenderMap();
                    break;
                case GameState.Win:
                    RenderMap();
                    System.Console.WriteLine("You win!");
                    break;
                case GameState.Lose:
                    System.Console.WriteLine("You lose!");
                    break;
                default:
                    System.Console.WriteLine("Unknown game state!");
                    break;
            }
        }

        System.Console.WriteLine();*/
    }

    protected override void HideImpl()
    {
        if (Context is not GameLayoutContext gameContext)
        {
            throw new WrongContextException();
        }

        gameContext.GameLogic = null;
    }

    private void PrepareGame()
    {
        var gameLogic = GetGameLogic();

        if (gameLogic is not null)
        {
            return;
        }
        
        gameLogic = new GameLogic(new StandardRandomGenerator(), new List<StateView> { new RunningGameStateView(gameLogic) });
        gameLogic.Start(10, 10, 20);

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

    private void RenderMap()
    {
        
    }

    protected override bool ProvideInputImpl(string input)
    {
        return false;
    }
}
