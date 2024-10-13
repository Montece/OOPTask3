using OOPTask3.Map;

namespace OOPTask3.Game.Cells.States;

public sealed class OpenedCellState(Cell cell) : CellState(cell)
{
    public override string Id => "Opened";
    public override string[] AvailableToChangeIds { get; } = [];
    public override CellState? PrimaryNextState => null;
    public override CellState? SecondaryNextState => null;
    public override char Mnemonics => GetBombsNumber().Value.ToString().FirstOrDefault();

    public CellNumber GetBombsNumber()
    {
        var bombsCount = 0;

        foreach (var direction in Enum.GetValues<Direction>())
        {
            var neighbour = Cell.CellsMap.GetElementNeighbour(Cell.Point, direction);
            if (neighbour != null)
            {
                bombsCount += neighbour.HasBomb ? 1 : 0;
            }
        }

        return new CellNumber(bombsCount);
    }
}