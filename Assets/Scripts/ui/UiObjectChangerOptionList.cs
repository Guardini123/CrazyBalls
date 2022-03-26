using QuantumTek.QuantumUI;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(QUI_OptionList))]
public class UiObjectChangerOptionList : MonoBehaviour
{
	private QUI_OptionList _objectChangerUI;

	[SerializeField] private List<GameObject> _objects = new List<GameObject>();

	[SerializeField] private string _keyForSaving;


	private void Start()
	{
		_objectChangerUI = this.GetComponent<QUI_OptionList>();

		_objectChangerUI.onChangeOption.AddListener(ChangeObject);

		var restoredObjectIndex = Load();

		_objectChangerUI.SetOption(restoredObjectIndex);
		ChangeObject();
	}


	/// <summary>
	/// Меняем игровой объект
	/// </summary>
	private void ChangeObject()
	{
		foreach(var obj in _objects)
		{
			if (obj.name.Equals(_objectChangerUI.option))
			{
				obj.SetActive(true);

			}
			else
			{
				obj.SetActive(false);
			}
		}

		Save();
	}


	private void Save()
	{
		IntSaverLoader.Instance.Save(_objectChangerUI.optionIndex, _keyForSaving);
	}


	private int Load()
	{
		var error = "";
		var index = 0;

		if(!IntSaverLoader.Instance.TryLoad(_keyForSaving, out index, out error))
		{
			Save();
			return _objectChangerUI.optionIndex;
		}

		return index;
	}
}