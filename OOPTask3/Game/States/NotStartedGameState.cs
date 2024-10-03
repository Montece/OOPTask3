namespace OOPTask3.Game.States;

public sealed class NotStartedGameState : GameState
{
    public override string Id => "NotStarted";

    public override string[] AvailableToChangeIds { get; } =
    [
        "Running"
    ];
}