namespace OOPTask3.Map;

public sealed class Vector(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public static Vector Upper { get; } = new(0, 1);
    public static Vector Lower { get; } = new(0, -1);
    public static Vector Right { get; } = new(1, 0);
    public static Vector Left { get; } = new(-1, 0);
    public static Vector UpperRight { get; } = new(1, 1);
    public static Vector LowerRight { get; } = new(1, -1);
    public static Vector UpperLeft { get; } = new(-1, 1);
    public static Vector LowerLeft { get; } = new(-1, 1);
}