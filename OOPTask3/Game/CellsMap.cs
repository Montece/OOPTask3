using JetBrains.Annotations;
using OOPTask3.Game.Cells;
using OOPTask3.Map;
using OOPTask3.StateMachine;

namespace OOPTask3.Game;

public sealed class CellsMap : Map2d<Cell>
{
    public CellsMap(int width, int height, List<StateView> views) : base(width, height)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var point = new Point(x, y);
                var cell = new Cell(point, views);
                SetElement(point, cell);
            }
        }
    }

    [MustUseReturnValue]
    public CellNumber CalculateBombsNumber(Point position)
    {
        var bombsCount = 0;

        foreach (var direction in NeighbourDirections)
        {
            var neighbourPosition = new Point(position.X + direction.X, position.Y + direction.Y);
            var neighbour = GetElement(neighbourPosition);

            if (neighbour != null)
            {
                bombsCount += neighbour.HasBomb ? 1 : 0;
            }
        }

        return new(bombsCount);
    }
}