namespace OOPTask3.StateMachine;

public abstract class StateView
{
    public abstract string Id { get; }

    public abstract void Render(State state);
}