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
        _player.ChangeHealth += ChangeAnimation;
    }

    private void OnDestroy()
    {
        _player.ChangeHealth -= ChangeAnimation;
    }

    private void ChangeAnimation(float currentHealth, float maxHealth)
    {
        float normalizedValue =  currentHealth / maxHealth;
        _animator.Play("PlayerState", 0, normalizedValue);
    }

}
