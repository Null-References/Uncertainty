using System;
using System.Collections.Generic;
using HealthSystem.Damage.DamageDealer;

namespace HealthSystem.Damage.DamageTaker
{
    public interface ITakeDamage
    {
        void TakeDamage(Dictionary<Type, IDamage> damageTypes);
    }
}