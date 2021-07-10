using UnityEngine;

namespace NPC.Enemy_AI
{
    public class LookAt : MonoBehaviour
    {
        [Range(0, -90)] [SerializeField] private float minX = 0f;
        [Range(0, 90)] [SerializeField] private float maxX = 30f;
        [Range(0, -90)] [SerializeField] private float minY = 0f;
        [Range(0, 90)] [SerializeField] private float maxY = 30f;

        [SerializeField] private Transform target;
        [SerializeField] private float smoothness = 0.1f;

        private Vector3 _defaultForward;
        private Quaternion _defaultRotation;

        private void Start()
        {
            var rotation = transform.rotation;
            _defaultForward = rotation.eulerAngles;
            _defaultRotation = rotation;
            if (!target)
            {
                Debug.Log($"Set target for Look at component On: {gameObject.name} ");
            }
        }

        private void Update()
        {
            if (!target) return;

            var direction = (target.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            float deltaX = Mathf.DeltaAngle(_defaultForward.x, rotation.eulerAngles.x);
            float deltaY = Mathf.DeltaAngle(_defaultForward.y, rotation.eulerAngles.y);
            if (deltaX < minX ||
                deltaX > maxX ||
                deltaY < minY ||
                deltaY > maxY)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, _defaultRotation, smoothness);
            }
            else
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothness);
        }
    }
}