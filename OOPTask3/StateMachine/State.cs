namespace OOPTask3.StateMachine;

public abstract class State : IState
{
    public abstract string Id { get; }
    public abstract string[] AvailableToChangeIds { get; }
}