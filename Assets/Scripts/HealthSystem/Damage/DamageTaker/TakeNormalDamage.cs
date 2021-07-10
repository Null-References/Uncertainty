using System;
using System.Collections.Generic;
using HealthSystem.Damage.DamageDealer;
using HealthSystem.HealthSys;
using UnityEngine;

namespace HealthSystem.Damage.DamageTaker
{
    [RequireComponent(typeof(Health))]
    public class TakeNormalDamage : MonoBehaviour, ITakeDamage
    {
        private Health _health;
        private void Start() => _health = GetComponent<Health>();

        public void TakeDamage(Dictionary<Type, IDamage> damageTypes)
        {
            var damageType = damageTypes[typeof(NormalDamage)] as NormalDamage;
            if (!(damageType is null))
                _health.ReduceHealth(damageType.Damage());
            //Debug.Log($"{gameObject.name} took damage from {damageType.name} amount : {damageType.Damage()}");
        }
    }
}