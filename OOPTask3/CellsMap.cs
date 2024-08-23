namespace OOPTask3;

internal sealed class CellsMap
{
    private readonly Cell[,] _cells;
    public uint Width { get; }
    public uint Height { get; }

    public CellsMap(uint width, uint height)
    {
        Width = width;
        Height = height;
        _cells = new Cell[width, height];
    }

    public Cell GetCell(Point position)
    {
        if (position.X > Width)
        {
            throw new ArgumentException("X value greater then the width of map", nameof(position));
        }

        if (position.Y > Height)
        {
            throw new ArgumentException("Y value greater then the height of map", nameof(position));
        }

        return _cells[position.X, position.Y];
    }
}