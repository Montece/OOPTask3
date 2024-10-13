using OOPTask3.Game.Cells.States;
using OOPTask3.Map;

namespace OOPTask3.Game.Cells;

public sealed class Cell
{
    public CellState State => _cellStateMachine.CurrentState;
    public bool HasBomb { get; private set; }
    public CellsMap CellsMap { get; private set; }
    public Point Point { get; private set; }

    private readonly CellStateMachine _cellStateMachine;

    public Cell(CellsMap cellsMap, Point point)
    {
        CellsMap = cellsMap;
        Point = point;
        _cellStateMachine = new(new ClearCellState(this));
    }

    public void PlaceBomb()
    {
        HasBomb = true;
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