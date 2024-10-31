using System.Windows;
using OOPTask3.StateMachine;

namespace OOPTask3.WPF.GameStateViews;

internal sealed class MvvmLoseGameStateView(CellViewModel cellViewModel) : MvvmGameStateView(cellViewModel)
{
    public override string Id => "Lose";

    public override void Render(State state)
    {
        MessageBox.Show("You lose!");
        Environment.Exit(0);
    }
}