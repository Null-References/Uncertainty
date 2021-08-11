using System.Collections.Generic;
using HealthSystem.Damage.DamageDealer;
using HealthSystem.Damage.DamageTaker;
using HealthSystem.Damage.DamageTaker.NPC;
using HealthSystem.HealthSys;
using NPC.Enemy_AI;
using UnityEngine;

namespace NPC
{
    [RequireComponent(typeof(EnemyMoveDataContainer))]
    public class WaspBot : MonoBehaviour , IHealth ,ITakeDamage
    {
        
        [SerializeField] private float maxHealth=100f;
        [SerializeField] private float currentShield = 100f;
        [SerializeField] private float currentHealth = 100f;
        [SerializeField] private float maxShield = 100f;
        
        public float MaxHealth =>maxHealth;
        public float CurrentHealth { get => currentHealth; set => currentHealth = value  ; }
        public float MaxShield => maxShield;
        public float CurrentShield { get => currentShield; set =>  currentShield = value;  }

        private WaspDamageTaker _damageTaker;
        private EnemyMoveDataContainer _container;

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

        public void TakeDamage(IDamageStats damageStats) => _damageTaker.Process(damageStats);
    }
}