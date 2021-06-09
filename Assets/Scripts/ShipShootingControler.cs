using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingControler : MonoBehaviour
{

    [SerializeField] private WeaponBase weapon;

    private ShipInputValueHandler _inputHandler;

    private void Start()
    {
        _inputHandler = GetComponent<ShipInputValueHandler>();
    }
    private void Update()
    {
        if (_inputHandler.GetShootInput()) 
        {
            weapon.Shoot();
        }
    }
}
