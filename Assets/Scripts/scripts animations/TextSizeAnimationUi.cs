using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextSizeAnimationUi : MonoBehaviour
{
	private TMP_Text _textTMP = null;

	[SerializeField] AnimationCurve _animCurve;

	private float _currentTime = 0.0f;
	private float _totalTime = 0.0f;

	private bool _canAnim = false;


	private void Start()
	{
		_textTMP = this.GetComponent<TMP_Text>();

		_totalTime = _animCurve.keys[_animCurve.keys.Length - 1].time;
	}


	private void Update()
	{
		if (_canAnim)
		{
			_textTMP.fontSize = _animCurve.Evaluate(_currentTime);

			_currentTime += Time.deltaTime;

			if (_currentTime >= _totalTime) _canAnim = false;
		}
	}

	public void StartAnim()
	{
		_canAnim = true;
		_currentTime = 0.0f;
	}
}
