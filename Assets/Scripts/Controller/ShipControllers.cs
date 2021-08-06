using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(ShipInputValueHandler))]
    public class ShipControllers : MonoBehaviour, IPhysicalMovable
    {

        [SerializeField] private Transform shipModel;

        [Header("Physic")] [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float torqueSpeed = 1f;
        [SerializeField] private float aimingTorqueSpeed = 1f;
        [SerializeField] private float rollSpeed = 1f;

        [Header("Visual")] [Range(0, 50)] [SerializeField]
        private float rollFanciness = 1f;

        [Range(0, 50)] [SerializeField] private float pitchFanciness = 1f;
        [SerializeField] private float fancinessSpeed = 1f;

        public Rigidbody Rigidbody => _rb;
        public Vector3 Direction => transform.forward;
        public float Speed => (_inputHandler.GetMoveValue * moveSpeed);

        private PhysicalMovement _physicalMovement;
        private Rigidbody _rb = null;
        private ShipInputValueHandler _inputHandler;
        private Vector2 _mouseValue = Vector2.zero;
        private float _currentTorqueSpeed;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _inputHandler = GetComponent<ShipInputValueHandler>();
            _physicalMovement = new PhysicalMovement(this);
        }

        private void FixedUpdate()
        {
            _physicalMovement.Move();
            Rotate();
        }

        private void Update()
        {
            _mouseValue = _inputHandler.GetMouseValue();
            Aim();

            VisualRotate();
        }

        private void Aim() => _currentTorqueSpeed = _inputHandler.GetAimingInput() ? aimingTorqueSpeed : torqueSpeed;
        
        private void Rotate()
        {
            //Physic part
            var torque = _mouseValue * _currentTorqueSpeed;
            var roll = _inputHandler.GetRollValue * rollSpeed;
            _rb.AddRelativeTorque(-torque.y, torque.x, -roll, ForceMode.VelocityChange);
        }

        private void VisualRotate()
        {
            //fancy part
            var targetRotation = Quaternion.Euler(_mouseValue.y * pitchFanciness, 180, _mouseValue.x * rollFanciness);
            shipModel.localRotation = Quaternion.Lerp(
                shipModel.localRotation,
                targetRotation,
                Time.deltaTime * fancinessSpeed
            );
        }
        
    }
}
