using System.Collections.Immutable;
using JetBrains.Annotations;

namespace OOPTask3.Map;

public abstract class Map2d<T>
{
    public int Width { get; }
    public int Height { get; }

    protected readonly ImmutableArray<Vector> NeighbourDirections =
    [
        Vector.Up,
        Vector.Down,
        Vector.Right,
        Vector.Left,
        Vector.UpRight,
        Vector.DownRight,
        Vector.UpLeft,
        Vector.DownLeft
    ];

    private readonly T[] _elements;

    protected Map2d(int width, int height)
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
            throw new ArgumentOutOfRangeException(nameof(width), "Cannot equals 0");
        }

        if (height == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Cannot equals 0");
        }

        Width = width;
        Height = height;

        _elements = new T[width * height];
    }

    public T? GetElement(Point position)
    {
        if (position.X >= Width || position.Y >= Height)
        {
            return default;
        }

        if (position.X < 0 || position.Y < 0)
        {
            return default;
        }

        return _elements[position.X + position.Y * Width];
    }

    public T[] GetElements()
    {
        return _elements;
    }

    public void SetElement(Point position, T element)
    {
        _elements[PositionToIndex(position)] = element;
    }

    [Pure]
    private int PositionToIndex(Point position)
    {
        return position.X + position.Y * Width;
    }
}