using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TakeNormalDamage : MonoBehaviour, ITakeDamage
{
    private Health _health;
    private void Start()
    {
        _health = GetComponent<Health>();
    }
    public void TakeDamage(Dictionary<Type, IDamage> damageTypes)
    {
        var damageType = damageTypes[typeof(NormalDamage)] as NormalDamage;
        _health.ReduceHealth(damageType.Damage());
        //Debug.Log($"{gameObject.name} took damage from {damageType.name} amount : {damageType.Damage()}");
    }
}