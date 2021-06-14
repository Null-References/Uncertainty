using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateTransition
{
    [Header("Next State")]
    [SerializeField] private State nextState;
    [Header("Conditions")]
    [SerializeField] private List<Condition> conditions;


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