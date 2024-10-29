using OOPTask3.Game.States;
using OOPTask3.Game.Views;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.GameStateViews;

internal sealed class NotStartedGameStateView : GameStateView
{
    public override string Id => "NotStarted";

    public override void Render(State state)
    {
        if (state is not NotStartedGameState)
        {
            return;
        }

        System.Console.WriteLine("Are you ready?");
    }
}