namespace OOPTask3.GameCell;

public sealed class Cell
{
    public bool HasBomb { get; private set; }
    public CellState State { get; private set; } = CellState.Clear;
    public CellNumber? Number { get; private set; }

    public void PlaceBomb()
    {
        HasBomb = true;
        Number = null;
    }

    public void ChangeStateTo(CellState newState)
    {
        State = newState;
    }

    public void SetNumber(CellNumber number)
    {
        Number = number;
    }
}