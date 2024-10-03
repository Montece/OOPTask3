using OOPTask3.StateMachine;

namespace OOPTask3.Game.Cells.States;

public abstract class CellState : State
{
    public abstract CellState? PrimaryNextState { get; }
    public abstract CellState? SecondaryNextState { get; }
}