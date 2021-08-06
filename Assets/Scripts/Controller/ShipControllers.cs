using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(ShipInputValueHandler))]
    public class ShipControllers : MonoBehaviour, IPhysicalMovable, IPhysicalRotatable
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
        public Vector2 TorqueForceValue => (_mouseValue * _currentTorqueSpeed);
        public float RollForceValue => (_inputHandler.GetRollValue * rollSpeed);
        public Vector3 Direction => transform.forward;
        public float Speed => (_inputHandler.GetMoveValue * moveSpeed);

        private PhysicalMovement _physicalMovement;
        private PhysicalRotation _physicalRotation;
        private Rigidbody _rb = null;
        private ShipInputValueHandler _inputHandler;
        private Vector2 _mouseValue = Vector2.zero;
        private float _currentTorqueSpeed;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _inputHandler = GetComponent<ShipInputValueHandler>();
            _physicalMovement = new PhysicalMovement(this);
            _physicalRotation = new PhysicalRotation(this);
        }

        private void FixedUpdate()
        {
            _physicalMovement.Move();
            _physicalRotation.Rotate();
        }

        private void Update()
        {
            _mouseValue = _inputHandler.GetMouseValue();
            Aim();

            VisualRotate();
        }

        private void Aim() => _currentTorqueSpeed = _inputHandler.GetAimingInput() ? aimingTorqueSpeed : torqueSpeed;

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