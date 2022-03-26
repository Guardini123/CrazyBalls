using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UiElementAnim : MonoBehaviour
{
	private Transform _tr = null;

	[SerializeField] AnimationCurve _animCurve;

	private float _currentTime = 0.0f;
	private float _totalTime = 0.0f;

	private bool _canAnim = false;

	private bool _animateToPlus = true;


	private void Start()
	{
		_tr = this.GetComponent<Transform>();

		_totalTime = _animCurve.keys[_animCurve.keys.Length - 1].time;
	}


	private void Update()
	{
		if (_canAnim)
		{
			if (_animateToPlus)
			{
				var newScale = new Vector3(_animCurve.Evaluate(_currentTime), _animCurve.Evaluate(_currentTime), 1.0f);
				_tr.localScale = newScale;

				_currentTime += Time.deltaTime;

				if (_currentTime >= _totalTime) _canAnim = false;
			}
			else
			{
				var newScale = new Vector3(_animCurve.Evaluate(_currentTime), _animCurve.Evaluate(_currentTime), 1.0f);
				_tr.localScale = newScale;

				_currentTime -= Time.deltaTime;

				if (_currentTime <= 0.0f) _canAnim = false;
			}	
		}
	}


	public void StartAnim()
	{
		_canAnim = true;
		_animateToPlus = true;
	}


	public void StopAnim()
	{
		_canAnim = true;
		_animateToPlus = false;
	}
}
