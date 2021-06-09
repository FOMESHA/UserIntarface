using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class View : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.position;
    }

    private void OnDisable()
    {
        _rectTransform.position = _startPosition;
    }
}
