using UnityEngine;

[RequireComponent(typeof(ShipInputValueHandler))]
public class ShipShootingController : MonoBehaviour
{
    [Tooltip("Which layers we can aim at")] [SerializeField]
    private LayerMask whatIsAimAbleLayer;

    [SerializeField] private Camera shipCamera;

    [Header("Ship Weapon")] [SerializeField]
    private WeaponBase weapon;

    [Tooltip("transform of the shooting point of the weapon")] [SerializeField]
    private Transform shootPoint;

    [Header("Aiming")] [SerializeField] private float aimRadius = 100;
    [SerializeField] private float aimMinDistance = 5f;

    private ShipInputValueHandler _inputHandler;
    private Vector3 _screenSpaceAimPoint;
    private void Start() => _inputHandler = GetComponent<ShipInputValueHandler>();

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
        Vector3 direction = worldSpaceAimPoint - shootPoint.position;
        if (Physics.Raycast(shipCamera.transform.position, direction, out var raycastHit, 50, whatIsAimAbleLayer))
            if (Vector3.Distance(raycastHit.point, shootPoint.position) > aimMinDistance)
                worldSpaceAimPoint = raycastHit.point;
    }

    private void CalculateScreenSpaceAimPoint()
    {
        //mouse pos in screen space
        Vector3 mousePos = Input.mousePosition;
        //difference vector from center to mousePos, pointing at mousePos
        Vector2 difference = mousePos - new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Vector2 result = difference;
        //if lenght of diff gone over radius we set it lenght to be inside circle
        float differenceLenght = difference.magnitude;
        if (differenceLenght > aimRadius)
            result = difference * (aimRadius / differenceLenght);

        //centralize aim sight vector
        _screenSpaceAimPoint = new Vector3(Screen.width / 2 + result.x, Screen.height / 2 + result.y, 50);
    }
}