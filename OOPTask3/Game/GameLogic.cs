using OOPTask3.Game.States;
using OOPTask3.Random;
using OOPTask3.StateMachine;

namespace OOPTask3.Game;

public sealed class GameLogic
{
    public GameState CurrentState => _gameStateMachine.CurrentState;

    private readonly IRandomGenerator _randomGenerator;
    private readonly GameStateMachine _gameStateMachine;

    public GameLogic(IRandomGenerator randomGenerator, List<StateView> views)
    {
        ArgumentNullException.ThrowIfNull(randomGenerator, nameof(randomGenerator));

        _randomGenerator = randomGenerator;

        _gameStateMachine = new(new NotStartedGameState(), views);
    }

    public void Start(int width, int height, int bombsCount)
    {
        _gameStateMachine.ChangeStateTo(new RunningGameState(width, height, bombsCount, _randomGenerator));
    }

    public void Render()
    {
        _gameStateMachine.Render();
    }
}