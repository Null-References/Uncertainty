using UnityEngine;

public class ShipInputValueHandler : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float deadZoneRadius = 0.6f;
    [SerializeField] private float deadZoneCoef = 3;

    private Controls _controls;
    private bool _isFreeLook = false;

    private void Awake()
    {
        _controls = new Controls();
        _controls.SpaceShip.Free_Look.performed += _ => ToggleFreeLook();
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

    public bool GetShootInput() => _controls.SpaceShip.Shoot.ReadValue<float>() > .1f;

    public bool GetAimingInput() => _controls.SpaceShip.Aiming.ReadValue<float>() > .1f;

    // triggered by Free_Look on controls asset
    private void ToggleFreeLook() => _isFreeLook = !_isFreeLook;

    public Vector2 GetMouseValue()
    {
        if (_isFreeLook) //TODO: this is dirty .maybe its own class just for camera
            return Vector2.zero;

        Vector2 mouseVec = _controls.SpaceShip.Steering_mouse.ReadValue<Vector2>();

        /*
        bias ing vectors to be form -width/2 to +width/2 not from 0 to width . also for height
        deviding by height normalizes the vector 
        min (height , width) 
        if do opposite , we will have value from -1 to 1 for width and somthing less than 1 for height
        so using height makes the circle with radius of 0.5 inside the screen
         */
        int height = Screen.height / 2;
        mouseVec = new Vector2(mouseVec.x - (Screen.width / 2), mouseVec.y - height) / height;

        //to make sure if dead zone is less than one ,vector dosent jump at lenght 1 when reached the zone so inside of the zone will be smooth regadless
        mouseVec /= deadZoneRadius;

        //used multiply and squered magnitude insted of root operation which is faster
        if (mouseVec.sqrMagnitude > deadZoneRadius * deadZoneRadius)
            //limits vector size to 1
            mouseVec = mouseVec.normalized;

        //makes mouse movment more aggresive
        mouseVec *= deadZoneCoef;
        return mouseVec;
    }

    public float GetRollValue => _controls.SpaceShip.Roll.ReadValue<float>();
    public float GetMoveValue => _controls.SpaceShip.Move_Forward_Backward.ReadValue<float>();
}