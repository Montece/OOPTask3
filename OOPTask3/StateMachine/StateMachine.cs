namespace OOPTask3.StateMachine;

public abstract class StateMachine<T> : IStateMachine<T> where T : State
{
    public T CurrentState { get; private set; }

    private readonly Dictionary<string, StateView> _views = new();

    protected StateMachine(T initialState, List<StateView> views)
    {
        ArgumentNullException.ThrowIfNull(initialState);
        ArgumentNullException.ThrowIfNull(views);

        CurrentState = initialState;

        foreach (var view in views)
        {
            _views[view.Id] = view;
        }
    }

    public bool ChangeStateTo(T nextState)
    {
        if (!CanChangeStateTo(nextState))
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

    public void Render()
    {
        _views[CurrentState.Id].Render(CurrentState);
    }
}