namespace OOPTask3;

public sealed class Cell
{
    public bool HasBomb { get; private set; } = false;
    public CellState CellState { get; private set; } = CellState.Clear;

    public void ChangeStateTo(CellState newState)
    {
        CellState = newState;
    }
}