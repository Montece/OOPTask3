namespace OOPTask3.Game.Cells.States;

public sealed class OpenedCellState : CellState
{
    public override string Id => "Opened";
    public override string[] AvailableToChangeIds { get; } = [];
    public override CellState? PrimaryNextState => null;
    public override CellState? SecondaryNextState => null;
}