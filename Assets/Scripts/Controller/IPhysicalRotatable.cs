using UnityEngine;

namespace Controller
{
    public interface IPhysicalRotatable
    {
        Rigidbody Rigidbody { get; }
        Vector2 TorqueForceValue { get; }
        float RollForceValue { get; }
    }
}