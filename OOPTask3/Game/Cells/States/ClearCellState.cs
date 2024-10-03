namespace OOPTask3.Game.Cells.States;

public sealed class ClearCellState : CellState
{
    public override string Id => "Clear";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Flag",
        "Opened"
    ];

    public override CellState? PrimaryNextState => new OpenedCellState();
    public override CellState? SecondaryNextState => new FlagCellState();
}