using OOPTask3.Game.Cells;
using OOPTask3.Map;
using OOPTask3.Random;
using OOPTask3.StateMachine;

namespace OOPTask3.Game.States;

public sealed class RunningGameState : GameState
{
    public override string Id => "Running";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Win",
        "Lose"
    ];

    public int Width { get; }
    public int Height { get; }
    private int MaxBombsCount => Width * Height;

    private readonly CellsMap _cellsMap;
    private readonly IRandomGenerator _randomGenerator;

    public RunningGameState(int width, int height, int bombsCount, IRandomGenerator randomGenerator, List<StateView> views)
    {
        if (width < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Should be less than 0");
        }

        if (height < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Should be less than 0");
        }

        if (width == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Should be equal 0");
        }

        if (height == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Should be equal 0");
        }

        Width = width;
        Height = height;

        ArgumentNullException.ThrowIfNull(randomGenerator, nameof(randomGenerator));
        ArgumentNullException.ThrowIfNull(views, nameof(views));

        _randomGenerator = randomGenerator;

        _cellsMap = new(Width, Height, views);

        PlaceBombs(bombsCount);
    }

    private void PlaceBombs(int bombsCount)
    {
        if (bombsCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Should be less than 0");
        }

        if (bombsCount > MaxBombsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Should be more than cells count");
        }

        var currentBombsCount = bombsCount;
        var availablePositions = new List<Point>();

        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                availablePositions.Add(new(x, y));
            }
        }

        while (currentBombsCount > 0 && availablePositions.Count > 0)
        {
            var bombPosition = availablePositions[_randomGenerator.GetNextRandomInt(0, availablePositions.Count)];

            var cell = _cellsMap.GetElement(bombPosition);

            if (cell is not null)
            {
                cell.PlaceBomb();
                currentBombsCount--;
            }

            availablePositions.Remove(bombPosition);
        }

        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                var position = new Point(x, y);
                var cell = _cellsMap.GetElement(position);
                cell?.SetBombsCount(_cellsMap.CalculateBombsNumber(position));
            }
        }
    }

    public void ChangeCellSecondaryState(Point position)
    {
        var cell = _cellsMap.GetElement(position);

        if (cell is null)
        {
            return;
        }

        var result = cell.ChangeStateToNextSecondary();

        if (!result)
        {
            throw new TransitionException($"Cannot change state to next secondary ({cell.State})");
        }
    }

    public void ChangeCellPrimaryState(Point position)
    {
        var cell = _cellsMap.GetElement(position);

        if (cell is null)
        {
            return;
        }

        var result = cell.ChangeStateToNextPrimary();

        if (!result)
        {
            throw new TransitionException($"Cannot change state to next primary ({cell.State})");
        }
    }

    public Cell? GetCell(Point position)
    {
        var cell = _cellsMap.GetElement(position);

        return cell;
    }

    public Cell[] GetCells()
    {
        var cells = _cellsMap.GetElements();

        return cells;
    }
}