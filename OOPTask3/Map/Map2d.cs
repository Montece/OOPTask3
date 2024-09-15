using JetBrains.Annotations;

namespace OOPTask3.Map;

public sealed class Map2d<T>
{
    public int Width { get; }
    public int Height { get; }

    private readonly T[] _elements;

    public Map2d(int width, int height)
    {
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

    public T[] GetCells()
    {
        return _elements;
    }

    public void SetElement(Point position, T element)
    {
        _elements[PositionToIndex(position)] = element;
    }

    [Pure]
    [MustUseReturnValue]
    private int PositionToIndex(Point position)
    {
        return position.X + position.Y * Width;
    }

    [Pure]
    [MustUseReturnValue]
    public T? GetElementNeighbour(Point position, Direction direction)
    {
        var cell = direction switch
        {
            Direction.Upper => GetElement(new(position.X, position.Y + 1)),
            Direction.Lower => GetElement(new(position.X, position.Y - 1)),
            Direction.Right => GetElement(new(position.X + 1, position.Y)),
            Direction.Left => GetElement(new(position.X - 1, position.Y)),
            Direction.UpperRight => GetElement(new(position.X + 1, position.Y + 1)),
            Direction.LowerRight => GetElement(new(position.X + 1, position.Y - 1)),
            Direction.UpperLeft => GetElement(new(position.X - 1, position.Y + 1)),
            Direction.LowerLeft => GetElement(new(position.X - 1, position.Y - 1)),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        return cell;
    }
}