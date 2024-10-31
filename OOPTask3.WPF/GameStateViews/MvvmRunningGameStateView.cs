using OOPTask3.Game.States;
using OOPTask3.StateMachine;

namespace OOPTask3.WPF.GameStateViews;

internal sealed class MvvmRunningGameStateView(CellViewModel cellViewModel) : MvvmGameStateView(cellViewModel)
{
    public override string Id => "Running";

    public override void Render(State state)
    {
        if (state is not RunningGameState runningGameState)
        {
            return;
        }

        CellViewModel.Cells.Clear();

        foreach (var cell in runningGameState.GetCells())
        {
            CellViewModel.Cells.Add(new(cell));
        }
    }
}