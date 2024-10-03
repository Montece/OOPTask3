namespace OOPTask3.Game.Cells.States;

public sealed class QuestionCellState : CellState
{
    public override string Id => "Question";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Clear",
        "Opened"
    ];

    public override CellState? PrimaryNextState => new OpenedCellState();
    public override CellState? SecondaryNextState => new ClearCellState();
}