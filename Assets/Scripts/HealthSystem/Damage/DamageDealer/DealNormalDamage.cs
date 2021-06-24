using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class DealNormalDamage : MonoBehaviour, IDealDamage
{
    public float DamageAmount = 5f;
    public float Damage() => DamageAmount;
}