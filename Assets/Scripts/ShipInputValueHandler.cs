
using UnityEngine;

public class ShipInputValueHandler : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float deadZoneRadius = 0.6f;
    [SerializeField] private float deadZoneCoef = 3;
    

    private Controls _controls;
    private bool _isFreeLook = false;

    private void Awake()
    {
        _controls = new Controls();
         _controls.SpaceShip.Free_Look.performed += _ => ToggleFreeLook();
        // controls.SpaceShip.Rotation.performed += ctx => Move(ctx.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void ToggleFreeLook()
    {
        _isFreeLook = !_isFreeLook;
    }
    public Vector2 GetMouseValue()
    {
        if (_isFreeLook)
            return Vector2.zero;

        Vector2 mouseVec = _controls.SpaceShip.Steering_mouse.ReadValue<Vector2>();
        //set mouse values to be between -1 , 1
        mouseVec = new Vector2(mouseVec.x - (Screen.width / 2), mouseVec.y - (Screen.height / 2)) / (Screen.width / 2);

        //clamp mouse vector lenght to certain value 
        if (mouseVec.magnitude > deadZoneRadius)
        {
            mouseVec = mouseVec.normalized * deadZoneRadius;
        }
        //enlarge the zone circle
        mouseVec *= deadZoneCoef;
        return mouseVec;
    }

}
