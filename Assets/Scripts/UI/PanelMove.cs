using System;
using DG.Tweening;
using UnityEngine;

public class PanelMove : MonoBehaviour
{
    [SerializeField] private DOTweenSettings _dotweenSettings;
    [SerializeField] private Vector2 _endPoint;
    private Vector2 _startPoint;

    private void Awake()
    {
        _startPoint = GetComponent<RectTransform>().anchoredPosition;
    }

    public void Move()
    {
        var rect = GetComponent<RectTransform>();
        
        rect
            .DOAnchorPos(_endPoint, _dotweenSettings.Duration)
            .SetEase(_dotweenSettings.EaseType);
    }

    public void MoveBack()
    {
        var rect = GetComponent<RectTransform>();
        
        rect
            .DOAnchorPos(_startPoint, _dotweenSettings.Duration)
            .SetEase(_dotweenSettings.EaseType);
    }
}
