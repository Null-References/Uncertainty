using System;
using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem.Damage.DamageDealer
{
    public class DamageDealer : MonoBehaviour
    {
        public Dictionary<Type, IDamage> DamageTypes { get; private set; }

        private void Start() //gathering all damage components
        {
            DamageTypes = new Dictionary<Type, IDamage>();

            var damages = GetComponents<IDamage>();
            foreach (var damage in damages)
            {
                DamageTypes.Add(damage.GetType(), damage);
            }
        }
    }
}