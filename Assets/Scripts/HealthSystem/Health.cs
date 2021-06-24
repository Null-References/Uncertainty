using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        
    }
    
    
    
}