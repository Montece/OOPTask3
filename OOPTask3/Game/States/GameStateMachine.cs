using OOPTask3.StateMachine;

namespace OOPTask3.Game.States;

public sealed class GameStateMachine(GameState initialState, List<StateView> views) : StateMachine<GameState>(initialState, views);