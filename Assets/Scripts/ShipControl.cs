using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{ 
    
    [SerializeField] private float moveSpeed = 1f;
    [Range(0,1)]
    [SerializeField] private float mouseDeadZone = 0.6f;
    [SerializeField] private float deadZoneCoef = 5;

    private Vector2 testVector;
    private Vector3 controlMousePos;
    private Vector3 controlMousePosAfter;

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

    private void Update()
    {
        Move(Vector2.zero);
    }

    private void Move(Vector2 dir)
    {

        Vector2 mouseVec = controls.SpaceShip.Steering_mouse.ReadValue<Vector2>();
        mouseVec = new Vector2(mouseVec.x- (Screen.width/2), mouseVec.y- (Screen.height/2)) /(Screen.width / 2);

       
        if (mouseVec.magnitude > mouseDeadZone)
        {
            mouseVec = mouseVec.normalized * mouseDeadZone;
        }

        testVector = new Vector3(mouseVec.x, mouseVec.y, 0)- transform.position;;
        Debug.Log(mouseVec * deadZoneCoef );
        // rb.AddForce(new Vector3(pos.x, 0, pos.y) * moveSpeed);
        //Debug.Log(1/Mathf.Pow(pos,2));
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(transform.position ,new Vector3( -testVector.x ,testVector.y,0)*deadZoneCoef);
        
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position + controlMousePos, 0.1f);

    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position + controlMousePosAfter, 0.1f);
    //}
}
