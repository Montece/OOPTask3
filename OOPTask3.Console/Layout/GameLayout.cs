using OOPTask3.Console.Commands;
using OOPTask3.Console.Layout.Context;
using OOPTask3.GameCell;

namespace OOPTask3.Console.Layout;

public sealed class GameLayout : ConsoleLayout
{
    public override string ID => "Game";
    public override ConsoleLayoutContext Context { get; } = new GameLayoutContext();
    public override ConsoleCommandsManager CommandsManager { get; } = new(
    [
        new OpenCellCommand(),
        new ToggleCellCommand(),
        new RestartGameCommand(RESTART_GAME_SHORTCUT),
        new MenuCommand(MENU_SHORTCUT),
    ]);

    private const int RESTART_GAME_SHORTCUT = 1;
    private const int MENU_SHORTCUT = 2;

    private GameLogic _gameLogic;

    public GameLayout(LayoutManager layoutManager) : base(layoutManager)
    {
    }

    protected override void ShowImpl()
    {
        if (Context is not GameLayoutContext gameContext)
        {
            throw new WrongContextException();
        }

        System.Console.Clear();
        System.Console.WriteLine("-. Open Cell <x> <y>");
        System.Console.WriteLine("-. Toggle Cell <x> <y>");
        System.Console.WriteLine($"{RESTART_GAME_SHORTCUT}. Restart Game");
        System.Console.WriteLine($"{MENU_SHORTCUT}. Back");
        System.Console.WriteLine();
        System.Console.WriteLine("===================");
        System.Console.WriteLine();

        if (gameContext.GameLogic == null || gameContext.GameLogic.State == GameState.NotStarted)
        {
            PrepareGame();
            RenderMap();
        }
        else
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

        System.Console.WriteLine();
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
        if (Context is not GameLayoutContext gameContext)
        {
            throw new WrongContextException();
        }

        gameContext.GameLogic = new GameLogic();
        _gameLogic = gameContext.GameLogic;

        gameContext.GameLogic.Start(10, 10);
    }

    private void RenderMap()
    {
        if (_gameLogic is null)
        {
            return;
        }

        /*for (var x = -1; x < _gameLogic.Width; x++)
        {
            for (var y = -1; y < _gameLogic.Height; y++)
            {
                if (x == -1)
                {
                    if (y == -1)
                    {
                        System.Console.Write(" ");
                    }
                    else
                    {
                        System.Console.Write(y);
                    }
                }
                else
                {
                    if (y == -1)
                    {
                        System.Console.Write(x);
                    }
                    else
                    {
                        var symbol = GetCellSymbol(_gameLogic.GetCell(new(x, y)));
                        System.Console.Write(symbol);
                    }
                }
            }

            System.Console.WriteLine();
        }*/

        for (var y = _gameLogic.Height - 1; y >= -1; y--)
        {
            for (var x = -1; x < _gameLogic.Width; x++)
            {
                if (x == -1)
                {
                    if (y == -1)
                    {
                        System.Console.Write(" ");
                    }
                    else
                    {
                        System.Console.Write(y);
                    }
                }
                else
                {
                    if (y == -1)
                    {
                        System.Console.Write(x);
                    }
                    else
                    {
                        var symbol = GetCellSymbol(_gameLogic.GetCell(new(x, y)));
                        System.Console.Write(symbol);
                    }
                }
            }

            System.Console.WriteLine();
        }
    }

    private static char GetCellSymbol(Cell cell)
    {
        switch (cell.State)
        {
            case CellState.Clear:
                return '#';
            case CellState.Flag:
                return '+';
            case CellState.Question:
                return '?';
            case CellState.Opened:
                if (cell.HasBomb)
                {
                    return '*';
                }

                return cell.Number is not null ? ((int)cell.Number).ToString()[0] : ' ';
            default:
                return ' ';
        }
    }

    protected override void ProvideInputImpl(string input)
    {
        
    }
}
