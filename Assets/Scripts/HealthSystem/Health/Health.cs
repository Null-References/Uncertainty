using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    public float _currentHealth;

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
        }
    }
}