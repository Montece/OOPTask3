using OOPTask3.GameCell;
using OOPTask3.Map;

namespace OOPTask3;

public sealed class GameLogic
{
    public GameState State { get; private set; } = GameState.NotStarted;
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int MaxBombsCount => Width * Height;

    private Map2d<Cell>? _cellsMap = null;
    private Random _random = new();

    public void Start(int width, int height, int bombsCount)
    {
        if (bombsCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Cannot be less then 0");
        }

        Width = width;
        Height = height;

        if (bombsCount > MaxBombsCount)
        {
            Width = 0;
            Height = 0;
            throw new ArgumentOutOfRangeException(nameof(bombsCount), "Cannot be more then cells count");
        }

        InitializeMap();
        PlaceBombs(bombsCount);
        CalculateNumbers();

        State = GameState.Running;
    }

    private void InitializeMap()
    {
        _cellsMap = new(Width, Height);

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                _cellsMap.SetElement(new(x, y), new Cell());
            }
        }
    }

    private void PlaceBombs(int bombsCount)
    {
        var currentBombsCount = bombsCount;

        if (currentBombsCount > MaxBombsCount)
        {
            currentBombsCount = MaxBombsCount;
        }

        var availablePositions = new List<Point>();

        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                availablePositions.Add(new(x, y));
            }
        }

        while (currentBombsCount  > 0 && availablePositions.Count > 0)
        {
            var bombPosition = availablePositions[_random.Next(0, availablePositions.Count)];
            _cellsMap.GetElement(bombPosition).PlaceBomb();

            currentBombsCount--;
            availablePositions.Remove(bombPosition);
        }
    }

    private void CalculateNumbers()
    {
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                var cell = _cellsMap.GetElement(new(x, y));

                if (cell.HasBomb)
                {
                    continue;
                }

                var bombsCount = 0;

                foreach (var direction in Enum.GetValues<Direction>())
                {
                    var neighbour = _cellsMap.GetElementNeighbour(new(x, y), direction);
                    if (neighbour != null)
                    {
                        bombsCount += neighbour.HasBomb ? 1 : 0;
                    }
                }
                
                var number = (CellNumber)bombsCount;
                cell.SetNumber(number);
            }
        }
    }

    public void ChangeCellState(Point position)
    {
        if (State != GameState.Running)
        {
            return;
        }

        var cell = _cellsMap.GetElement(position);

        if (cell is null)
        {
            return;
        }

        switch (cell.State)
        {
            case CellState.Clear:
                cell.ChangeStateTo(CellState.Flag);
                break;
            case CellState.Flag:
                cell.ChangeStateTo(CellState.Question);
                break;
            case CellState.Question:
                cell.ChangeStateTo(CellState.Clear);
                break;
            case CellState.Opened:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cell.State), cell.State, null);
        }
    }

    public void OpenCell(Point position)
    {
        if (State != GameState.Running)
        {
            return;
        }

        var cell = _cellsMap.GetElement(position);

        if (cell is null || cell.State == CellState.Opened)
        {
            return;
        }

        cell.ChangeStateTo(CellState.Opened);

        if (cell.HasBomb)
        {
            State = GameState.Lose;
        }
        else
        {
            //var areBombsLeft = _cellsMap.GetElements().Where();
        }
    }

    public Cell? GetCell(Point position)
    {
        if (State != GameState.Running || _cellsMap == null)
        {
            return default;
        }

        var cell = _cellsMap.GetElement(position);

        return cell;
    }

    public Cell?[]? GetCells()
    {
        if (State != GameState.Running || _cellsMap == null)
        {
            return default;
        }

        var cells = _cellsMap.GetElements();

        return cells;
    }
}