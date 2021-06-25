using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class NormalDamage : MonoBehaviour, IDamage
{
    public float DamageAmount = 5f;
    public float Damage() => DamageAmount;
}