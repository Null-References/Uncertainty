using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{ 
    
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float mouseSensivity = 1f;
    [Range(0,1)]
    [SerializeField] private float mouseDeadZone = 0.6f;
    [SerializeField] private float deadZoneCoef = 5;


    private Rigidbody rb = null;
    private Controls controls;
    
    private void Awake()
    {
        controls = new Controls();
        
       // controls.SpaceShip.Rotation.performed += ctx => Move(ctx.ReadValue<Vector2>());
       
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FixedUpdate()
    {
        var torque = GetMouseValue() * mouseSensivity * Time.fixedDeltaTime;
        rb.AddRelativeTorque(torque.y, torque.x, 0);
    }

    private Vector2 GetMouseValue()
    {
        //TODO:stop rotating around with a button or delta value
        
        Vector2 mouseVec = controls.SpaceShip.Steering_mouse.ReadValue<Vector2>();
        
        //set mouse values to be between -1 , 1
        mouseVec = new Vector2(mouseVec.x- (Screen.width/2), mouseVec.y- (Screen.height/2)) /(Screen.width / 2);
        
        //clamp mouse vector lenght to certain value 
        if (mouseVec.magnitude > mouseDeadZone)
        {
            mouseVec = mouseVec.normalized * mouseDeadZone;
        }
        //enlarge the zone circle
        mouseVec *= deadZoneCoef;

        return mouseVec;
    }

   
}
