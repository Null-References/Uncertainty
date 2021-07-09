using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NPC.Enemy_AI.StateMachine
{
    public class State : MonoBehaviour, IState
    {
        [SerializeField] private List<StateTransition> transitions;
        [SerializeField] private UnityEvent OnEnter;
        [SerializeField] private UnityEvent OnExit;

        public void Enter() => OnEnter.Invoke();

        public void Exit() => OnExit.Invoke();

        public IState ProcessTransition()
        {
            foreach (var tran in transitions)
            {
                var nextState = tran.GetNextStateIfConditionMet();
                if (nextState)
                {
                    return nextState;
                }
            }

            return null;
        }
    }
}