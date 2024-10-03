namespace OOPTask3.StateMachine;

internal interface IStateMachine<T> where T : IState
{
    public T CurrentState { get; }

    public bool ChangeStateTo(T nextState);

    public bool CanChangeStateTo(T nextState);
}