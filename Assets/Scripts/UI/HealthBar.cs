using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private float _timeToFill;

    private Slider _slider;
    private float _elapsedTime;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _player.ChangeHealth += OnChangeSliderValue;
    }


    private void OnDestroy()
    {
        _player.ChangeHealth -= OnChangeSliderValue;
    }

    public void OnChangeSliderValue(float currentHealth, float maxHealth)
    {
        StopAllCoroutines();
        _healthText.text = currentHealth.ToString();
        StartCoroutine(FillBar(currentHealth, maxHealth));
    }

    private IEnumerator FillBar(float currentHealth = 0, float maxHealth = 0)
    {
        _elapsedTime = 0;

        while (_elapsedTime < _timeToFill)
        {
            float newValue = Mathf.MoveTowards(_slider.value, currentHealth / maxHealth, (_elapsedTime / _timeToFill) * Time.deltaTime);
            _slider.value = newValue;
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        _slider.value = currentHealth / maxHealth;
    }
}
