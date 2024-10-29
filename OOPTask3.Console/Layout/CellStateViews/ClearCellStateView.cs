using OOPTask3.Game.Cells.States;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.CellStateViews;

internal sealed class ClearCellStateView : StateView
{
    public override string Id => "Clear";

    public override void Render(State state)
    {
        if (state is not ClearCellState clearCellState)
        {
            return;
        }

        System.Console.Write(clearCellState.Mnemonics);
    }
}