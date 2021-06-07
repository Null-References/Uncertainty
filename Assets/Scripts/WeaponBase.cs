using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform shotPoint;

    private RepeatableTimer _timer;

    private void Awake()
    {
        _timer = new RepeatableTimer(fireRate);
    }
    private void Update()
    {
        _timer.Tick(Time.deltaTime);
        if (_timer.IsReady())
        {
            Instantiate(projectile.gameObject, shotPoint.position,shotPoint.rotation);
        }
    }
}
