
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private UnityEvent OnDeath;
    [SerializeField] private UnityEvent OnTakeDamage;

    private float _currentHealth;
    private void OnEnable() => ResetHealth();

    public void ResetHealth() => _currentHealth = maxHealth;

    private void Start() => ResetHealth();
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
    public float GetHealthPercent() => _currentHealth / maxHealth;
}
