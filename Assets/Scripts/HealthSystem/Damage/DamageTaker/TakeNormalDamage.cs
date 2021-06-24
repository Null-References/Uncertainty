using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TakeNormalDamage : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(Dictionary<Type, IDealDamage> damageTypes)
    {
        var damageType = damageTypes[typeof(DealNormalDamage)] as DealNormalDamage;
        Debug.Log($"{gameObject.name} took damage from {damageType.name} amount : {damageType.Damage()}");
    }
}