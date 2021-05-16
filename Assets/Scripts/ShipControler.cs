using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControler : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float torqueSpeed = 1f;

    private Rigidbody _rb = null;
    private ShipInputValueHandler _inputHandler;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputHandler = GetComponent<ShipInputValueHandler>();
    }

    private void FixedUpdate()
    {
        var torque = _inputHandler.GetMouseValue() * torqueSpeed * Time.fixedDeltaTime;
        _rb.AddRelativeTorque(torque.y, torque.x, 0);
    }
    

}
