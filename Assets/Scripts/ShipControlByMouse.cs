using UnityEngine;
/*public class ShipControlByMouse : Controler
{
  
    private KeyMap keys;
    private Transform shipBody;

    private Transform shipTransform;
    private Rigidbody ship_rb;
    private int moveSpeed;
    private int mouseSensivity;
    private Vector3 rotSpeedVector;

    private float mouseX;
    private float mouseY;
    private float moveForward;
    private float rotZ;


    public ShipControlByMouse(Transform shipbody, Transform t, Rigidbody ship, int movespeed, int mousesens, Vector3 rotvectormult)
    {
        keys = new KeyMap
        {
            freelook = KeyCode.Tab,
            moveB = KeyCode.S,
            moveF = KeyCode.W,
            moveV = 0,

            rotZI = KeyCode.A,
            rotZD = KeyCode.D,
            rotZV = 0,

            rotYI = KeyCode.None,
            rotYD = KeyCode.None,
            rotYV = 0,

            rotXI = KeyCode.None,
            rotXD = KeyCode.None,
            rotXV = 0
        };

        shipBody = shipbody;
        shipTransform = t;
        ship_rb = ship;
        moveSpeed = movespeed;
        mouseSensivity = mousesens;
        rotSpeedVector = rotvectormult;

    }
    public override void Move()
    {
        moveForward = UseInput(ref keys.moveV, 0.7f, keys.moveF, keys.moveB) * moveSpeed * Time.fixedDeltaTime;
        rotZ = UseInput(ref keys.rotZV, 0.7f, keys.rotZI, keys.rotZD) * Time.fixedDeltaTime * 5;

        //mouse position from center screen
        mouseX = (Mathf.Clamp((Input.mousePosition).x, 0, Screen.width) / Screen.width - 0.5f) * mouseSensivity * Time.fixedDeltaTime;
        mouseY = (Mathf.Clamp((Input.mousePosition).y, 0, Screen.height) / Screen.height - 0.5f) * mouseSensivity * Time.fixedDeltaTime;

        float v = 1+(1 - (ship_rb.velocity.magnitude / 12));
        v = Mathf.Clamp(v, 1, 3);
        if (!Input.GetKey(keys.freelook))
        {
            //add force to rotate ship
            ship_rb.AddRelativeTorque(-mouseY * rotSpeedVector.x*v , mouseX * rotSpeedVector.y*v , (rotZ) * rotSpeedVector.z *v);
            shipBody.localRotation = Quaternion.Lerp(shipBody.localRotation, Quaternion.Euler( -mouseY*100,0, -mouseX * 450), 0.1f);
        }
        //add force to move ship
        ship_rb.AddForce(shipTransform.forward * moveForward, ForceMode.Force);
    }
}*/
