using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiRoundIndicatorImage : MonoBehaviour
{
    [SerializeField] private Image _roundImage;
    [SerializeField] private TMP_Text _textIndicator;

    [Space]
    [SerializeField] private Image _indicatorImage;
    [SerializeField] private Color32 _filledCollor;
    [SerializeField] private Color32 _unfilledCollor;

    [Space]
    [SerializeField] private MovementController _targetMovContr;

    private float _full;
    private float _delta;


    void Start()
    {
        _full = _targetMovContr.DelayForJump;
    }

    
    void Update()
    {
        _delta = _full - _targetMovContr.DelayForJumpDelta;
        _textIndicator.text = _delta.ToString("0.0");

        var fillAmount = _delta / _full;
        _roundImage.fillAmount = fillAmount;

        if (fillAmount >= 1.0f) _indicatorImage.color = _filledCollor;
        else _indicatorImage.color = _unfilledCollor;
    }
}
