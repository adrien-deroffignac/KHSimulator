using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;
    [SerializeField] TextMeshProUGUI _healthText;
    

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }
    
    private void Update()
    {
        if (_healthText != null)
        {
            _healthText.text = $"{CurrentHealth} / {_maxHealth}";
        }
    }
}
