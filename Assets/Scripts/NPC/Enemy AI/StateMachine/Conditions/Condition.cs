using UnityEngine;

namespace NPC.Enemy_AI.StateMachine.Conditions
{
    public abstract class Condition : MonoBehaviour
    {
        public abstract bool IsMet { get; }
    }
}
