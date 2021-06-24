using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public Dictionary<Type, IDealDamage> DamageTypes { get; private set; }

    private void Start() //gathering all damage components
    {
        DamageTypes = new Dictionary<Type, IDealDamage>();

        var damages = GetComponents<IDealDamage>();
        foreach (var damage in damages)
        {
            DamageTypes.Add(damage.GetType(), damage);
        }
    }
}