namespace Controller
{
    public class PhysicalMovement
    {
        private IPhysicalMovable _movable;

        public PhysicalMovement(IPhysicalMovable movable) => _movable = movable;

        public void Move() => _movable.Rigidbody.AddForce(_movable.Direction * _movable.Speed);
    }
}