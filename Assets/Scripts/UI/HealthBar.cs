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
    private Coroutine _fillBarJob;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _player.OnChangeHealth += ChangeSliderValue;
    }


    private void OnDestroy()
    {
        _player.OnChangeHealth -= ChangeSliderValue;
    }

    public void ChangeSliderValue(float currentHealth, float maxHealth)
    {
        if (_fillBarJob != null)
            StopCoroutine(_fillBarJob);

        _healthText.text = currentHealth.ToString();
        _fillBarJob = StartCoroutine(FillBar(currentHealth, maxHealth));
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
