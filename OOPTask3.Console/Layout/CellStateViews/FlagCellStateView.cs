using OOPTask3.Game.Cells.States;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.CellStateViews;

internal sealed class FlagCellStateView : StateView
{
    public override string Id => "Flag";

    public override void Render(State state)
    {
        if (state is not FlagCellState flagCellState)
        {
            return;
        }

        System.Console.Write(flagCellState.Mnemonics);
    }
}