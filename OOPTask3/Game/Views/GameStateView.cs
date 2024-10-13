using OOPTask3.StateMachine;

namespace OOPTask3.Game.Views;

public abstract class GameStateView : StateView
{
    protected GameLogic _gameLogic;

    protected GameStateView(GameLogic gameLogic)
    {
        ArgumentNullException.ThrowIfNull(gameLogic);

        _gameLogic = gameLogic;
    }
}