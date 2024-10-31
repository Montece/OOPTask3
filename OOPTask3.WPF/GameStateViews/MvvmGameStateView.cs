using OOPTask3.Game.Views;
using OOPTask3.StateMachine;

namespace OOPTask3.WPF.GameStateViews;

internal abstract class MvvmGameStateView(CellViewModel cellViewModel) : GameStateView
{
    public abstract override string Id { get; }
    protected CellViewModel CellViewModel { get; } = cellViewModel;

    public abstract override void Render(State state);
}