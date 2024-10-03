using OOPTask3.Game.States;
using OOPTask3.Random;

namespace OOPTask3.Game;

public sealed class GameLogic
{
    private readonly IRandomGenerator _randomGenerator;
    private readonly GameStateMachine _gameStateMachine;

    public GameLogic(IRandomGenerator randomGenerator)
    {
        ArgumentNullException.ThrowIfNull(randomGenerator, nameof(randomGenerator));

        _randomGenerator = randomGenerator;

        _gameStateMachine = new(new NotStartedGameState());
    }

    public void Start(int width, int height, int bombsCount)
    {
        _gameStateMachine.ChangeStateTo(new RunningGameState(width, height, bombsCount, _randomGenerator));
    }
}