using OOPTask3.Game.Cells.States;
using OOPTask3.Map;
using OOPTask3.StateMachine;

namespace OOPTask3.Game.Cells;

public sealed class Cell
{
    public CellState State => _cellStateMachine.CurrentState;
    public bool HasBomb { get; private set; }
    public CellNumber BombsCount { get; private set; }
    public Point Point { get; private set; }

    private readonly CellStateMachine _cellStateMachine;

    public Cell(Point point, List<StateView> views)
    {
        ArgumentNullException.ThrowIfNull(point);
        ArgumentNullException.ThrowIfNull(views);

        Point = point;
        _cellStateMachine = new(new ClearCellState(this), views);
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

    public void Render()
    {
        _cellStateMachine.Render();
    }

    public void SetBombsCount(CellNumber bombsCount)
    {
        BombsCount = bombsCount;
    }
}