using UnityEngine;
[RequireComponent(typeof(SimpleProjectilePool))]
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

    public void Shoot()
    {
        _timer.Tick(Time.deltaTime);
        if (_timer.IsReady())
        {
            var projectile = SimpleProjectilePool.Instance.Get();
            projectile.transform.position = shotPoint.position;
            projectile.transform.rotation = shotPoint.rotation;
            projectile.gameObject.SetActive(true);
        }
    }
}
