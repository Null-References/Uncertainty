﻿public class StateMachine
{
    public IState CurrentState { get; private set; }

    public StateMachine(IState startState) => ChangeState(CurrentState);

    public void ChangeState(IState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }

    public void Tick()
    {
        var newState = CurrentState.ProcessTransition();
        if (newState != null)
            ChangeState(newState);
    }
}