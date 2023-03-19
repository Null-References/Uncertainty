using UnityEngine;

namespace Controller
{
    public interface IPhysicalMovable
    {
        Rigidbody Rigidbody { get; }
        Vector3 Direction { get; }
        float Speed { get; }
    }
}