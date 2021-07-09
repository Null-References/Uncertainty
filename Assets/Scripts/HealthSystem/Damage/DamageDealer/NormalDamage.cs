using UnityEngine;

namespace HealthSystem.Damage.DamageDealer
{
    [RequireComponent(typeof(DamageDealer))]
    public class NormalDamage : MonoBehaviour, IDamage
    {
        public float damageAmount = 5f;
        public float Damage() => damageAmount;
    }
}