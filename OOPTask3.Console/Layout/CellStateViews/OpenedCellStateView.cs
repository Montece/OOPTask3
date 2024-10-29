using OOPTask3.Game.Cells.States;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.CellStateViews;

internal sealed class OpenedCellStateView : StateView
{
    public override string Id => "Opened";

    public override void Render(State state)
    {
        if (state is not OpenedCellState openedCellState)
        {
            return;
        }

        System.Console.Write(openedCellState.Mnemonics);
    }
}