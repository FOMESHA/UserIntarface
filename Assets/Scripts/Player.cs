using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event UnityAction<float, float> ChangeHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        ChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
        ChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }

    public void GetHealth(int health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        ChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }
}
