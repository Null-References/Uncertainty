using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private UnityEvent OnDeath;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }
    public void ReduceHealth(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth<=0)
        {
            Debug.Log($"{gameObject.name} Died");
            OnDeath.Invoke();
        }
    }
}
