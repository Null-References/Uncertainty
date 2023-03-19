using UnityEngine;

namespace Controller
{
    public class PhysicalRotation
    {
        private IPhysicalRotatable _rotatable;

        public PhysicalRotation(IPhysicalRotatable rotatable)
        {
            _rotatable = rotatable;
        }

        public void Rotate()
        {
            _rotatable.Rigidbody.AddRelativeTorque(
                -_rotatable.TorqueForceValue.y,
                _rotatable.TorqueForceValue.x,
                -_rotatable.RollForceValue,
                ForceMode.VelocityChange
            );
        }
    }
}