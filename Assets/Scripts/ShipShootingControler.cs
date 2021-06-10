using UnityEngine;
/// <summary>
/// gets input and aims the gun
/// </summary>
[RequireComponent(typeof(ShipInputValueHandler))]
public class ShipShootingControler : MonoBehaviour
{
    [Tooltip("Which layers we can aim at")]
    [SerializeField] LayerMask aimableLayer;
    [SerializeField] private Camera shipCamera;
    [Header("Ship Weapon")]
    [SerializeField] private WeaponBase weapon;
    [Tooltip("transform of the shooting point of the weapon")]
    [SerializeField] Transform shootPoint;
    
    [Header("Aiming")]
    [SerializeField] float aimRaduis = 100;
    [SerializeField] float aimMinDistance = 5f;    

    private ShipInputValueHandler _inputHandler;
    private Vector3 _screenSpaceAimPoint;
    private void Start()
    {
        _inputHandler = GetComponent<ShipInputValueHandler>();
    }
    private void Update()
    {
        CalculateScreenSpaceAimPoint();
        var worldSpaceAimPoint = shipCamera.ScreenToWorldPoint(_screenSpaceAimPoint);
        GetRaycastHitPoint(ref worldSpaceAimPoint);

        shootPoint.LookAt(worldSpaceAimPoint);

        if (_inputHandler.GetShootInput())
        {
            weapon.Shoot();
        }
    }

    private void GetRaycastHitPoint(ref Vector3 worldSpaceAimPoint)
    {
        RaycastHit raycastHit;
        Vector3 direction = worldSpaceAimPoint - shootPoint.position;
        if (Physics.Raycast(shipCamera.transform.position, direction, out raycastHit, 50, aimableLayer))
        {
            if (Vector3.Distance(raycastHit.point, shootPoint.position) > aimMinDistance)
            {
                worldSpaceAimPoint = raycastHit.point;
            }
        }
        //Debug.DrawLine(shootPoint.position, worldSpaceAimPoint, Color.red);
    }

    private void CalculateScreenSpaceAimPoint()
    {
        //mouse pos in screen space
        Vector3 mousePos = Input.mousePosition;
        //deffrence vector from center to mousePos, pointing at mousePos
        Vector2 diffrence = mousePos - new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Vector2 result = diffrence;
        //if lenght of diff gone over raduis we set it lenght to be inside circle
        float diffrenceLenght = diffrence.magnitude;
        if (diffrenceLenght > aimRaduis)
            result = diffrence * (aimRaduis / diffrenceLenght);

        //centerize aimsight vector
        _screenSpaceAimPoint = new Vector3(Screen.width / 2 + result.x, Screen.height / 2 + result.y, 50);
    }
}
