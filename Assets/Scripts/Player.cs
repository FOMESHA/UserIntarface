using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event UnityAction<float, float> OnChangeHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        OnChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
        OnChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }

    public void GetHealth(int health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        OnChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }
}
