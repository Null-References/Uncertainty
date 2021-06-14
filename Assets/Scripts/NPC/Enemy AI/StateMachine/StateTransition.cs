using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateTransition
{
    [SerializeField] private List<Conditions> conditions;
    [SerializeField] private State nextState;

    public StateTransition(State nextState) => this.nextState = nextState;

    public State GetNextStateIfConditionMet()
    {
        if (conditions.AreMet())
        {
            return nextState;
        }

        return null;
    }
}