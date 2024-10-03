using OOPTask3.Game.Cells.States;

namespace OOPTask3.Game.Cells;

public sealed class Cell
{
    public CellState State => _cellStateMachine.CurrentState;
    public bool HasBomb { get; private set; }
    public CellNumber? Number { get; private set; }

    private CellStateMachine _cellStateMachine;

    public void SetNumber(CellNumber number)
    {
        Number = number;
    }

    public void PlaceBomb()
    {
        HasBomb = true;
        Number = null;
    }

    public bool ChangeStateToNextPrimary()
    {
        return _cellStateMachine.ExecutePrimaryTransition();
    }

    public bool ChangeStateToNextSecondary()
    {
        return _cellStateMachine.ExecuteSecondaryTransition();
    }
}