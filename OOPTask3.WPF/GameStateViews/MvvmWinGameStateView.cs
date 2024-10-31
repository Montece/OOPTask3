using System.Windows;
using OOPTask3.StateMachine;

namespace OOPTask3.WPF.GameStateViews;

internal sealed class MvvmWinGameStateView(CellViewModel cellViewModel) : MvvmGameStateView(cellViewModel)
{
    public override string Id => "Win";

    public override void Render(State state)
    {
        MessageBox.Show("You win!");
        Environment.Exit(0);
    }
}