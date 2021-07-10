using Timer;
using UnityEngine;

namespace Weapons.Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private float fireRate;
        [SerializeField] protected float damage;
        [SerializeField] protected Transform shotPoint;

        protected RepeatableTimer _timer;

        private void Awake() => _timer = new RepeatableTimer(fireRate);

        public abstract void Shoot();
    }
}