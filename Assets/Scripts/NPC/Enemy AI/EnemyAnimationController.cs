using UnityEngine;

namespace NPC.Enemy_AI
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        public void SetShooting() => animator.SetBool(Shoot, true);

        public void SetIdle() => animator.SetBool(Shoot, false);
    }
}