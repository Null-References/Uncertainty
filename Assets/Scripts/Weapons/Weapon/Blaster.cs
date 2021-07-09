using UnityEngine;
using Weapons.Projectile;

namespace Weapons.Weapon
{
    class Blaster : WeaponBase
    {
        private int _ownerID;

        private void Start()
        {
            var theCollider = GetComponentInParent<Collider>();
            if (theCollider != null)
            {
                _ownerID = theCollider.GetInstanceID();
            }
        }

        public override void Shoot()
        {
            _timer.Tick(Time.deltaTime);
            if (_timer.IsReady())
            {
                var projectile = NormalBulletPool.Instance.Get();
                SetProjectileSettings(projectile);
            }
        }

        private void SetProjectileSettings(NormalBullet projectile)
        {
            projectile.SetOwner(_ownerID);
            var tempTransform = projectile.transform;
            tempTransform.position = shotPoint.position;
            tempTransform.rotation = shotPoint.rotation;
            projectile.SetDamage(damage);
            projectile.gameObject.SetActive(true);
        }
    }
}