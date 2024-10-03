namespace OOPTask3.StateMachine;

internal interface IState
{
    public string Id { get; }
    public string[] AvailableToChangeIds { get; }
}