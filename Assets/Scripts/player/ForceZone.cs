using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForceZone : MonoBehaviour
{
	[SerializeField] private float _forse;

	[Space]
	[SerializeField] private float _xMult;
	[SerializeField] private float _yMult;
	[SerializeField] private float _zMult;

	Vector3 _forceDir = new Vector3();

	private void OnTriggerStay(Collider other)
	{
		Rigidbody rb = null;
		try
		{
			rb = other.GetComponent<Rigidbody>();
		} 
		catch (Exception e)
		{
			return;
		}

		_forceDir.x = _xMult;
		_forceDir.y = _yMult;
		_forceDir.z = _zMult;

		_forceDir = _forceDir.normalized;
		rb.AddForce(_forceDir * _forse, ForceMode.Force);
	}
}
