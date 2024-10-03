namespace OOPTask3.StateMachine;

public abstract class StateMachine<T> : IStateMachine<T> where T : State
{
    public T CurrentState { get; private set; }

    protected StateMachine(T initialState)
    {
        ArgumentNullException.ThrowIfNull(initialState);

        CurrentState = initialState;
    }

    public bool ChangeStateTo(T nextState)
    {
        if (CanChangeStateTo(nextState))
        {
            return false;
        }

        CurrentState = nextState;

        return true;
    }

    public bool CanChangeStateTo(T nextState)
    {
        return CurrentState.AvailableToChangeIds.Contains(nextState.Id);
    }
}