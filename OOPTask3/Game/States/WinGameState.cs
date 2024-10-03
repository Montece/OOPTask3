namespace OOPTask3.Game.States;

public sealed class WinGameState : GameState
{
    public override string Id => "Win";

    public override string[] AvailableToChangeIds { get; } = [];
}