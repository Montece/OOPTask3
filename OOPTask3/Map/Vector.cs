namespace OOPTask3.Map;

public sealed class Vector
{
    public int X { get; }
    public int Y { get; }

    public static Vector Upper { get; } = new(0, 1);
    public static Vector Lower { get; } = new(0, -1);
    public static Vector Right { get; } = new(1, 0);
    public static Vector Left { get; } = new(-1, 0);
    public static Vector UpperRight { get; } = new(1, 1);
    public static Vector LowerRight { get; } = new(1, -1);
    public static Vector UpperLeft { get; } = new(-1, 1);
    public static Vector LowerLeft { get; } = new(-1, 1);

    private Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
}