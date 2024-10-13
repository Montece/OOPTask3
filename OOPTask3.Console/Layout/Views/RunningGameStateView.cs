using OOPTask3.Game;
using OOPTask3.Game.States;
using OOPTask3.Game.Views;
using OOPTask3.StateMachine;

namespace OOPTask3.Console.Layout.Views;

internal sealed class RunningGameStateView(GameLogic gameLogic) : GameStateView(gameLogic)
{
    public override string Id => "Running";

    public override void Render(State state)
    {
        if (state is not RunningGameState running)
        {
            return;
        }

        for (var y = running.Height - 1; y >= -1; y--)
        {
            for (var x = -1; x < running.Width; x++)
            {
                if (x == -1)
                {
                    if (y == -1)
                    {
                        System.Console.Write(" ");
                    }
                    else
                    {
                        System.Console.Write(y);
                    }
                }
                else
                {
                    if (y == -1)
                    {
                        System.Console.Write(x);
                    }
                    else
                    {
                        var symbol = running.GetCell(new(x, y)).State.Mnemonics;
                        System.Console.Write(symbol);
                    }
                }
            }

            System.Console.WriteLine();
        }
    }
}