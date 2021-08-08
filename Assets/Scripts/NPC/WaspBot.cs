using System.Collections.Generic;
using HealthSystem.Damage.DamageDealer;
using HealthSystem.Damage.DamageTaker;
using HealthSystem.HealthSys;
using NPC.Enemy_AI;
using UnityEngine;

namespace NPC
{
    /// <summary>
    /// this class handles bots needs and sets diffrent dependencies for weapons and stuff
    /// </summary>
    [RequireComponent(typeof(EnemyMoveDataContainer))]
    public class WaspBot : MonoBehaviour , IHealth ,ITakeDamage
    {
        private WaspDamageTaker _damageTaker;
        private EnemyMoveDataContainer _container;
        [SerializeField]
        private float _maxHealth=100f;
        public float MaxHealth =>_maxHealth;
        [SerializeField]
        private float _currentHealth = 100f;
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value  ; }
        [SerializeField]
        private float _maxShield = 100f;
        public float MaxShield => _maxShield;
        [SerializeField]
        private float _currentShield = 100f;
        public float CurrentShield { get { return _currentShield; } set =>  _currentShield = value;  }


        private void OnEnable()
        {
            if (_container == null)
                _container = GetComponent<EnemyMoveDataContainer>();
        }
        private void Start() => _damageTaker = new WaspDamageTaker(this);

        public void SetPathPoints(List<Transform> points) => _container.pathPoints = points;

        public void SetSpeed(float speed) => _container.speed = speed;

        public void ReturnToPool() => WaspBotPool.Instance.ReturnToPool(this);

        public void ReduceNumberOfAliveBots()
        {
        }

        public void TakeDamage(IDamageStats damageStats)
        {
            _damageTaker.Process(damageStats);
        }
    }
}