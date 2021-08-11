using HealthSystem.Damage.DamageDealer;
using HealthSystem.Damage.DamageTaker;
using Timer;
using UnityEngine;

namespace Weapons.Projectile
{
    [RequireComponent(typeof(NormalDamage))]
    public class NormalBullet : MonoBehaviour, IProjectile
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float lifeTime = 2f;
        [SerializeField] private LayerMask whatIsCollidable;

        private int _owner;
        private NonRepeatableTimer _timer;
        private DamageDealer _dealer;
        private NormalDamage _normalDamage;

        private void OnEnable() => _timer.ResetTimer();

        private void Awake()
        {
            _normalDamage = GetComponent<NormalDamage>();
            _timer = new NonRepeatableTimer(lifeTime);
            _timer.OnTimerEnded += DeSpawn;
        }

        private void Start() => _dealer = GetComponent<DamageDealer>();

        public void OnTriggerEnter(Collider other)
        {
            //Debug.Log($"{other.name} : {other.GetInstanceID()}");
            if (_owner == other.GetInstanceID())
                return;

            if ((whatIsCollidable.value & (1 << other.gameObject.layer)) <= 0)
                return;

            var target = other.GetComponent<ITakeDamage>();
            if (target == null)
                return;

            target.TakeDamage(_dealer.DamageTypes);
            

            DeSpawn();
        }


        private void Update()
        {
            _timer.Tick(Time.deltaTime);
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }

        public void SetOwner(int ownerID) => _owner = ownerID;

        public void SetDamage(float damage) => _normalDamage.damageAmount = damage;
        private void DeSpawn() => NormalBulletPool.Instance.ReturnToPool(this);
    }
}