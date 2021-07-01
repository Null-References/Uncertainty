namespace IL3DN
{
    using UnityEngine;
    [ExecuteInEditMode]

    public class IL3DN_Wind : MonoBehaviour
    {
        private float WindGizmo = 0.5f;

        void Update()
        {

            Shader.SetGlobalVector("WindDirection", transform.rotation * Vector3.back);

        }

        void OnDrawGizmos()
        {
            Vector3 dir = (transform.position + transform.forward).normalized;

            Gizmos.color = Color.green;
            Vector3 up = transform.up;
            Vector3 side = transform.right;

            Vector3 end = transform.position + transform.forward * (WindGizmo * 5f);
            Vector3 mid = transform.position + transform.forward * (WindGizmo * 2.5f);
            Vector3 start = transform.position + transform.forward * (WindGizmo * 0f);

            float s = WindGizmo;
            Vector3 front = transform.forward * WindGizmo;

            Gizmos.DrawLine(start, start - front + up * s);
            Gizmos.DrawLine(start, start - front - up * s);
            Gizmos.DrawLine(start, start - front + side * s);
            Gizmos.DrawLine(start, start - front - side * s);
            Gizmos.DrawLine(start, start - front * 2);

            Gizmos.DrawLine(mid, mid - front + up * s);
            Gizmos.DrawLine(mid, mid - front - up * s);
            Gizmos.DrawLine(mid, mid - front + side * s);
            Gizmos.DrawLine(mid, mid - front - side * s);
            Gizmos.DrawLine(mid, mid - front * 2);

            Gizmos.DrawLine(end, end - front + up * s);
            Gizmos.DrawLine(end, end - front - up * s);
            Gizmos.DrawLine(end, end - front + side * s);
            Gizmos.DrawLine(end, end - front - side * s);
            Gizmos.DrawLine(end, end - front * 2);

        }
    }
}