namespace OOPTask3.Game.Cells.States;

public sealed class ClearCellState(Cell cell) : CellState(cell)
{
    public override string Id => "Clear";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Flag",
        "Opened"
    ];

    public override CellState PrimaryNextState => new OpenedCellState(Cell);
    public override CellState SecondaryNextState => new FlagCellState(Cell);
    public override char Mnemonics => '*';
}