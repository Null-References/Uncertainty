using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateTransition 
{

    [SerializeField] private List<Conditions> conditions;
    [SerializeField] private State _nextState;

    public StateTransition(State nextState)
    {
        _nextState = nextState;
    }

    public State GetNextStateIfConditionMet()
    {
        if (Conditions.CheckAllConditions(conditions))
        {
            return _nextState;
        }
        return null;
    }
}
