using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace NPC.Enemy_AI.StateMachine
{
    [Serializable]
    public class StateTransition
    {
        [Header("Next State")] [SerializeField]
        private State nextState;

        [Header("Conditions")] [SerializeField]
        private List<Conditions.Condition> conditions;


        public StateTransition(State nextState) => this.nextState = nextState;

        public State GetNextStateIfConditionMet() => conditions.AreMet() ? nextState : null;
    }
}