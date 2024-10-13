namespace OOPTask3.Game.Cells.States;

public sealed class FlagCellState(Cell cell) : CellState(cell)
{
    public override string Id => "Flag";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Question",
        "Opened"
    ];

    public override CellState PrimaryNextState => new OpenedCellState(Cell);
    public override CellState SecondaryNextState => new QuestionCellState(Cell);
    public override char Mnemonics => 'F';
}