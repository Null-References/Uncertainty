using UnityEngine;

class Blaster : WeaponBase
{
    public override void Shoot()
    {
        _timer.Tick(Time.deltaTime);
        if (_timer.IsReady())
        {
            var projectile = NormalBulletPool.Instance.Get();
            projectile.transform.position = shotPoint.position;
            projectile.transform.rotation = shotPoint.rotation;
            projectile.gameObject.SetActive(true);
        }
    }
}