using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstShowElement : MonoBehaviour
{
	[SerializeField] private string _keyForSaving;

	public UnityEvent OnNotFirstOpening;


	private void Start()
	{
		var value = "";
		var error = "";

		if (!StringSaverLoader.Instance.TryLoad(_keyForSaving, out value, out error))
		{
			StringSaverLoader.Instance.Save("first", _keyForSaving);
		}
		else
		{
			OnNotFirstOpening?.Invoke();
		}
	}
}
