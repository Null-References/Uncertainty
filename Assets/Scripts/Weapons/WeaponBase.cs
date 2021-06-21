using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] protected Transform shotPoint;

    protected RepeatableTimer _timer;

    private void Awake() => _timer = new RepeatableTimer(fireRate);

    public abstract void Shoot();
}