using UnityEngine;

namespace NPC.Enemy_AI
{
    public abstract class EnemyMoveState : MonoBehaviour
    {
        protected abstract void Update();
        protected abstract void GetDependencies();
    }
}