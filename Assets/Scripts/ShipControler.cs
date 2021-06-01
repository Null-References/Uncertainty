using UnityEngine;

[RequireComponent(typeof(ShipInputValueHandler))]
public class ShipControler : MonoBehaviour
{   
    [SerializeField] Transform shipModel;
    
    [Header("Physic")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float torqueSpeed = 1f;
    [SerializeField] private float rollSpeed = 1f;

    [Header("Visual")]
    [Range(0, 50)]
    [SerializeField] private float rollFanciness = 1f;
    [Range(0, 50)]
    [SerializeField] private float pitchFanciness = 1f;
    [SerializeField] private float fancinessSpeed = 1f;


    private Rigidbody _rb = null;
    private ShipInputValueHandler _inputHandler;
    private Vector2 _mouseValue = Vector2.zero;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputHandler = GetComponent<ShipInputValueHandler>();
    }
    private void FixedUpdate()
    {
        Move();
        Rotate();
    }
    private void Update()
    {
        _mouseValue = _inputHandler.GetMouseValue();

        VisualRotate();
    }

    private void Move()
    {
        _rb.AddForce(transform.forward * _inputHandler.GetMoveValue * moveSpeed);
    }
    private void Rotate()
    {
        //Physic part
        var torque = _mouseValue * torqueSpeed;
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
