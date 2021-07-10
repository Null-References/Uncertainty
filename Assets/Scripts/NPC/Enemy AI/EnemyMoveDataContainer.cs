using System.Collections.Generic;
using UnityEngine;

namespace NPC.Enemy_AI
{
    public class EnemyMoveDataContainer : MonoBehaviour
    {
        [SerializeField] public float speed = 2;

        [Tooltip("this is squered")] [SerializeField]
        public float targetMinDistance = 25;

        [Tooltip("this is squered")] [SerializeField]
        public float targetMaxDistance = 64;

        [SerializeField] public List<Transform> pathPoints;
        [SerializeField] public float timeToNextPoint = 15f; //TODO : rename this thing
        [Range(0, 1)] public float rotationSmoothness = 0.1f;
        [Range(0, 1)] public float positionSmoothness = 0.1f;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            var position = transform.position;
            Gizmos.DrawWireSphere(position, Mathf.Sqrt(targetMinDistance));
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(position, Mathf.Sqrt(targetMaxDistance));
        }
    }
}