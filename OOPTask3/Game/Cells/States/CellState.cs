using OOPTask3.StateMachine;

namespace OOPTask3.Game.Cells.States;

public abstract class CellState(Cell cell) : State
{
    public abstract CellState? PrimaryNextState { get; }
    public abstract CellState? SecondaryNextState { get; }
    protected Cell Cell { get; } = cell;
    public abstract char Mnemonics { get; }
}