namespace OOPTask3.Game.Cells.States;

public sealed class QuestionCellState(Cell cell) : CellState(cell)
{
    public override string Id => "Question";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Clear",
        "Opened"
    ];

    public override CellState PrimaryNextState => new OpenedCellState(Cell);
    public override CellState SecondaryNextState => new ClearCellState(Cell);
    public override char Mnemonics => '?';
}