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

    public int Width { get; private set; }
    public int Height { get; private set; }
    public int MaxBombsCount => Width * Height;

    private readonly CellsMap _cellsMap;
    private readonly IRandomGenerator _randomGenerator;

    public RunningGameState(int width, int height, int bombsCount, IRandomGenerator randomGenerator)
    {
        ArgumentNullException.ThrowIfNull(randomGenerator, nameof(randomGenerator));
        _randomGenerator = randomGenerator;

        if (width < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Cannot be less then 0");
        }

        if (height < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Cannot be less then 0");
        }

        if (width == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Cannot equals 0");
        }

        if (height == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Cannot equals 0");
        }

        Width = width;
        Height = height;

        if (bombsCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Cannot be less then 0");
        }

        if (bombsCount > MaxBombsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Cannot be more then cells count");
        }

        _cellsMap = new(Width, Height);

        PlaceBombs(bombsCount);
    }

    private void PlaceBombs(int bombsCount)
    {
        if (bombsCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Cannot be less then 0");
        }

        if (bombsCount > MaxBombsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Cannot be more then cells count");
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

        if (cell.HasBomb)
        {
            
        }
        else
        {
            //var areBombsLeft = _cellsMap.GetElements().Where();
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