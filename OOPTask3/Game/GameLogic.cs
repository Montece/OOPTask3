using OOPTask3.Game.States;
using OOPTask3.Random;
using OOPTask3.StateMachine;

namespace OOPTask3.Game;

public sealed class GameLogic
{
    public GameState CurrentState => _gameStateMachine.CurrentState;

    private readonly IRandomGenerator _randomGenerator;
    private readonly GameStateMachine _gameStateMachine;
    private readonly List<StateView> _cellViews;

    public GameLogic(IRandomGenerator randomGenerator, List<StateView> gameViews, List<StateView> cellViews)
    {
        ArgumentNullException.ThrowIfNull(randomGenerator, nameof(randomGenerator));
        ArgumentNullException.ThrowIfNull(gameViews, nameof(gameViews));
        ArgumentNullException.ThrowIfNull(cellViews, nameof(cellViews));

        _randomGenerator = randomGenerator;

        _gameStateMachine = new(new NotStartedGameState(), gameViews);
        _cellViews = cellViews;
    }

    public void Start(int width, int height, int bombsCount)
    {
        _gameStateMachine.ChangeStateTo(new RunningGameState(width, height, bombsCount, _randomGenerator, _cellViews));
    }

    public void CheckEnd()
    {
        if (CurrentState is not RunningGameState running)
        {
            return;
        }

        var cells = running.GetCells();
        var bombIsOpen = cells.FirstOrDefault(c => c.State.Id == "Opened" && c.HasBomb) != null;

        if (bombIsOpen)
        {
            _gameStateMachine.ChangeStateTo(new LoseGameState());
            return;
        }

        var allBombsFound = cells.Where(c => c.HasBomb).All(c => c.State.Id == "Flag");
        var allNotBombsOpened = cells.Where(c => !c.HasBomb).All(c => c.State.Id == "Opened");

        if (allBombsFound && allNotBombsOpened)
        {
            _gameStateMachine.ChangeStateTo(new WinGameState());
        }
    }

    public void Render()
    {
        _gameStateMachine.Render();
    }
}