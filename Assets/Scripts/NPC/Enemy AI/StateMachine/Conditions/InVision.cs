using UnityEditor;
using UnityEngine;

namespace NPC.Enemy_AI.StateMachine.Conditions
{
    public class InVision : Condition
    {
        [SerializeField] private LayerMask whatIsTarget;
        [SerializeField] private float radius = 1f;
        [SerializeField] private Transform center;

        [Tooltip("cosine of degree between target and front if this object")] [Range(-1, 1)] [SerializeField]
        private float vision;

        private Collider[] _colliderBuffer = new Collider[1];

        public override bool IsMet
        {
            get
            {
                if (Physics.OverlapSphereNonAlloc(center.position, radius, _colliderBuffer, whatIsTarget) > 0)
                {
                    var targetDir = _colliderBuffer[0].transform.position - transform.position;
                    if (Vector3.Dot(targetDir.normalized, transform.forward.normalized) > vision)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (!center)
                return;
            Handles.color = Color.yellow;
            float angle = Mathf.Acos(vision) * Mathf.Rad2Deg;
            var up = center.up;
            var from = Quaternion.AngleAxis(-angle, up) * center.forward;
            Handles.DrawSolidArc(center.position, up, from, angle * 2, radius);
        }
    }
}