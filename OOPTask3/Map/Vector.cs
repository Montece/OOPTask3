namespace OOPTask3.Map;

public sealed class Vector
{
    public int X { get; }
    public int Y { get; }

    public static Vector Up { get; } = new(0, 1);
    public static Vector Down { get; } = new(0, -1);
    public static Vector Right { get; } = new(1, 0);
    public static Vector Left { get; } = new(-1, 0);
    public static Vector UpRight { get; } = new(1, 1);
    public static Vector DownRight { get; } = new(1, -1);
    public static Vector UpLeft { get; } = new(-1, 1);
    public static Vector DownLeft { get; } = new(-1, 1);

    private Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
}