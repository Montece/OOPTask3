namespace OOPTask3.Game.States;

public sealed class LoseGameState : GameState
{
    public override string Id => "Lose";

    public override string[] AvailableToChangeIds { get; } = [];
}