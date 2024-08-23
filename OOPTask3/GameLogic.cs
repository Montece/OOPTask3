namespace OOPTask3;

public sealed class GameLogic
{
    public bool IsStarted { get; private set; }

    private CellsMap? _cellsMap = null;

    public void Start()
    {
        _cellsMap = new(15, 15);
        IsStarted = true;
    }

    public void ChangeCellState(Point position)
    {
        if (!IsStarted)
        {
            return;
        }

        var cell = _cellsMap.GetCell(position);

        switch (cell.CellState)
        {
            case CellState.Clear:
                cell.ChangeStateTo(CellState.Flag);
                break;
            case CellState.Flag:
                cell.ChangeStateTo(CellState.Question);
                break;
            case CellState.Question:
                cell.ChangeStateTo(CellState.Clear);
                break;
            case CellState.Opened:
                break;
            default:
                break;
        }
    }

    public void Stop()
    {

    }
}