using OOPTask3.StateMachine;

namespace OOPTask3.WPF.GameStateViews;

internal sealed class MvvmNotStartedGameStateView(CellViewModel cellViewModel) : MvvmGameStateView(cellViewModel)
{
    public override string Id => "NotStarted";

    public override void Render(State state)
    {
    }
}