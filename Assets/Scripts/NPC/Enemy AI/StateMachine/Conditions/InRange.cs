using System;
using UnityEngine;

namespace NPC.Enemy_AI.StateMachine.Conditions
{
    [Serializable]
    public class InRange : Condition
    {
        [SerializeField] private LayerMask whatIsTarget;
        [SerializeField] private float radius = 1f;
        [SerializeField] private Transform center;

        private Collider[] _colliderBuffer = new Collider[1];

        public override bool IsMet =>
            Physics.OverlapSphereNonAlloc(center.position, radius, _colliderBuffer, whatIsTarget) > 0;

        private void OnDrawGizmosSelected()
        {
            if (!center)
                return;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(center.position, radius);
        }
    }
}