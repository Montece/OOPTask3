namespace OOPTask3.Game.Cells;

public sealed class CellNumber
{
    public int Value;

    private const int MIN_VALUE = 0;
    private const int MAX_VALUE = 8;

    public CellNumber(int value)
    {
        if (value < MIN_VALUE)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Cannot be less then {MIN_VALUE}");
        }

        if (value > MAX_VALUE)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Cannot be more then {MAX_VALUE}");
        }

        Value = value;
    }
}