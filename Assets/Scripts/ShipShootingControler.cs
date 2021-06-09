using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingControler : MonoBehaviour
{

    [SerializeField] private WeaponBase weapon;

    [SerializeField] private Camera cam;
    [SerializeField] Transform shopPoint;
    [SerializeField] float aimCircleBiggness = 100;
    private ShipInputValueHandler _inputHandler;
    private void Start()
    {
        _inputHandler = GetComponent<ShipInputValueHandler>();
    }
    private void Update()
    {
        Vector3 v = Input.mousePosition;
        Vector2 dist = v- new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 result = dist;
        if (dist.magnitude>aimCircleBiggness)
        {
            result = dist * (aimCircleBiggness / dist.magnitude);
        }
        Debug.Log($"{result.magnitude} ");
        var aimPoint =cam.ScreenToWorldPoint(new Vector3 (Screen.width / 2 +result.x, Screen.height / 2+result.y,50));

        shopPoint.LookAt(aimPoint);

        if (_inputHandler.GetShootInput()) 
        {
            weapon.Shoot();
        }
    }
}
