namespace OOPTask3.Game.Cells.States;

public sealed class FlagCellState : CellState
{
    public override string Id => "Flag";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Question",
        "Opened"
    ];

    public override CellState? PrimaryNextState => new OpenedCellState();
    public override CellState? SecondaryNextState => new QuestionCellState();
}