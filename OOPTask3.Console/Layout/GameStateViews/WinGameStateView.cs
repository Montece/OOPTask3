using OOPTask3.Game.States;
using OOPTask3.Game.Views;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.GameStateViews;

internal sealed class WinGameStateView : GameStateView
{
    public override string Id => "Win";

    public override void Render(State state)
    {
        if (state is not WinGameState)
        {
            return;
        }

        System.Console.WriteLine("You win!");
    }
}