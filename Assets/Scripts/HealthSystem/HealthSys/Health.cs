using UnityEngine;
using UnityEngine.Events;

namespace HealthSystem.HealthSys
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private UnityEvent OnDeath;
        [SerializeField] private UnityEvent OnTakeDamage;

        private float _currentHealth;
        private void OnEnable() => _currentHealth = maxHealth;

        private void Start() => _currentHealth = maxHealth;

        public void ReduceHealth(float amount)
        {
            OnTakeDamage?.Invoke();
            // Debug.Log($"{gameObject.name} : {_currentHealth}");
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                // Debug.Log($"{gameObject.name} Died");
                OnDeath.Invoke();
            }
        }
    }
}