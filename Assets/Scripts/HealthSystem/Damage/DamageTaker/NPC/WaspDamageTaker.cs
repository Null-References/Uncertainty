using HealthSystem.Damage.DamageDealer;
using HealthSystem.Damage.DamageTaker;
using HealthSystem.HealthSys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspDamageTaker 
{
    private IHealth _health;

    public WaspDamageTaker(IHealth health)
    {
        _health = health;
    }
    public void Process(IDamageStats damageStats)
    {
        throw new System.NotImplementedException();
    }
}
