using UnityEngine;

class Blaster : WeaponBase
{
    private int _ownerID;
    private void Start()
    {
        var collider = GetComponentInParent<Collider>();
        if (collider != null)
        {
            _ownerID =collider.GetInstanceID();
        }
    }
    public override void Shoot()
    {
        _timer.Tick(Time.deltaTime);
        if (_timer.IsReady())
        {
            var projectile = NormalBulletPool.Instance.Get();
            projectile.SetOwner(_ownerID);
            projectile.transform.position = shotPoint.position;
            projectile.transform.rotation = shotPoint.rotation;
            projectile.gameObject.SetActive(true);
        }
    }
}