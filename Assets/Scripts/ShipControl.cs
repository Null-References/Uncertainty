using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{ 
    
    [SerializeField] private float moveSpeed = 1f;
    
    
    private Rigidbody rb = null;
    private Controls controls;


    private void Awake()
    {
        controls = new Controls();
        
        controls.SpaceShip.Rotation.performed += ctx => Move(ctx.ReadValue<Vector2>());
       
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
        Move(Vector2.zero);
    }

    private void Move(Vector2 dir)
    {

        Vector2 pos = controls.SpaceShip.Rotation.ReadValue<Vector2>();
        rb.AddForce(new Vector3(pos.x, 0, pos.y) * moveSpeed);
        Debug.Log(dir.ToString());
    }

}
