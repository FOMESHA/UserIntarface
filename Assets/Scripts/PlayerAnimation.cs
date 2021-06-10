using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.ChangeHealth += OnChangeAnimation;
    }

    private void OnDestroy()
    {
        _player.ChangeHealth -= OnChangeAnimation;
    }

    private void OnChangeAnimation(float currentHealth, float maxHealth)
    {
        float normalizedValue =  currentHealth / maxHealth;
        _animator.Play("PlayerState", 0, normalizedValue);
    }

}
