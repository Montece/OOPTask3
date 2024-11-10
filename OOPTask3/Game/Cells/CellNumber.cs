namespace OOPTask3.Game.Cells;

public sealed class CellNumber
{
    public int Value { get; }

    private const int MIN_VALUE = 0;
    private const int MAX_VALUE = 8;

    public CellNumber(int value)
    {
        if (value < MIN_VALUE)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Should be less than {MIN_VALUE}");
        }

        if (value > MAX_VALUE)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Should be more than {MAX_VALUE}");
        }

        Value = value;
    }
}