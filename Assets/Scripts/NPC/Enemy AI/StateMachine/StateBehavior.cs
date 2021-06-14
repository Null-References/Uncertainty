using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehavior : MonoBehaviour
{
    [SerializeField] private State startState;

    private StateMachine _stateMachine;

    public StateMachine StateMachine
    {
        get
        {
            if (_stateMachine != null)
                return _stateMachine;
            _stateMachine = new StateMachine(startState);
            return _stateMachine;
        }
    }

    private void Update() => StateMachine.Tick();

    public void ChangeState(State newState)
    {
        StateMachine.ChangeState(newState);
    }
    
}
