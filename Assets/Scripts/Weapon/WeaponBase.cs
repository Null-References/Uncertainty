using UnityEngine;
[RequireComponent(typeof(ProjectilePool))]
public class WeaponBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform shotPoint;

    private RepeatableTimer _timer;

    private void Awake()
    {
        _timer = new RepeatableTimer(fireRate);
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        _timer.Tick(Time.deltaTime);
        if (_timer.IsReady())
        {
            ProjectilePool.Instance.Get();
        }
    }
}
