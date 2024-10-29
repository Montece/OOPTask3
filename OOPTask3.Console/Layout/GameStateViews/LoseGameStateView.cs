using OOPTask3.Game.States;
using OOPTask3.Game.Views;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.GameStateViews;

internal sealed class LoseGameStateView : GameStateView
{
    public override string Id => "Lose";

    public override void Render(State state)
    {
        if (state is not LoseGameState)
        {
            return;
        }

        System.Console.WriteLine("You lose!");
    }
}