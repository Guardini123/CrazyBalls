using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaleAnimation : MonoBehaviour
{
	private Transform _tr = null;

	[SerializeField] AnimationCurve _animCurve;

	private float _currentTime = 0.0f;
	private float _totalTime = 0.0f;

	private bool _canAnim = false;


	private void Start()
	{
		_tr = this.GetComponent<Transform>();

		_totalTime = _animCurve.keys[_animCurve.keys.Length - 1].time;
	}


	private void Update()
	{
		if (_canAnim)
		{
			var newScale = new Vector3(_animCurve.Evaluate(_currentTime), _animCurve.Evaluate(_currentTime), 1.0f);
			_tr.localScale = newScale;

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
