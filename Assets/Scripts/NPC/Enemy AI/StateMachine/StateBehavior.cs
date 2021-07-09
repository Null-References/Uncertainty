using Timer;
using UnityEngine;

namespace NPC.Enemy_AI.StateMachine
{
    public class StateBehavior : MonoBehaviour
    {
        [SerializeField] private State startState;

        [Tooltip("the time period between each reactivation, More -> Performance++, Quality--")]
        [Range(0, 5)]
        [SerializeField]
        private float offTime = 0.1f;

        private StateMachine _stateMachine;
        private RepeatableTimer _timer;

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

        private void Start() => _timer = new RepeatableTimer(offTime);

        private void Update()
        {
            _timer.Tick(Time.deltaTime);
            if (_timer.IsReady())
                StateMachine.Tick();
        }

        public void ChangeState(State newState) => StateMachine.ChangeState(newState);
    }
}