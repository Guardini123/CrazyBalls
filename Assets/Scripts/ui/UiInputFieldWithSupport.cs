using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_InputField))]
public class UiInputFieldWithSupport : MonoBehaviour
{
	[Header("Additional string for recent value.")]
	[SerializeField] private string _additionalString;

	[Header("Layout for supports btns.")]
	[SerializeField] private Transform _supportBtnsContainer;

    [Header("Put your support btns here.")]
    [SerializeField] private List<UiSupportBtnForInputField> _supportBtns = new List<UiSupportBtnForInputField>();

	[Header("Key by what need to save value from this IF.")]
	[SerializeField] private string _keyForSaving;

	[Header("Special btn for recent value")]
	[SerializeField] private UiSupportBtnForInputField _btnRecent;

	public TMP_InputField InputField { get; private set; }

	[Header("Set max value from support btns if you whant use easter egg")]
	[SerializeField] private string _maxValue;
	[SerializeField] private string _textMaxValueForRecentBtn;


	private void Start()
	{
		InputField = this.GetComponent<TMP_InputField>();
		foreach(var btn in _supportBtns)
		{
			btn.Init(InputField);
		}

		Load();
	}


	public void Save()
	{
		StringSaverLoader.Instance.Save(InputField.text, _keyForSaving);
	}


	private void Load()
	{
		_btnRecent.gameObject.SetActive(false);
		var lastValue = StringSaverLoader.Instance.Load(_keyForSaving);


		if (StringSaverLoader.Instance.CheckKey(_keyForSaving))
		{
			_btnRecent.gameObject.SetActive(true);

			if (_maxValue.Equals(lastValue))
			{
				_btnRecent.SetTexts(_textMaxValueForRecentBtn, lastValue);
				return;
			}

			for (int i = 1; i < _supportBtns.Count; i++)
			{
				if (_supportBtns[i].TextToIf.Equals(lastValue))
				{
					_btnRecent.SetTexts(_supportBtns[i].BtnText, lastValue);
					return;
				}
			}

			_btnRecent.SetTexts(lastValue + _additionalString, lastValue);
		}

		UpdateLayout(_supportBtnsContainer, 1);
	}


	/// <summary>
	/// Обновляет вёрстку в layout group
	/// </summary>
	/// <param name="layout"> Объект с компонентом layout group </param>
	/// <param name="layoutMode"> 0 - vertical, 1 - horizontal </param>
	private void UpdateLayout(Transform layout, int layoutMode)
	{
		if (layoutMode == 0)
		{
			var verticalLayout = layout.gameObject.GetComponent<VerticalLayoutGroup>();
			verticalLayout.CalculateLayoutInputVertical();
		}
		else if (layoutMode == 1)
		{
			var horizontalLayout = layout.gameObject.GetComponent<HorizontalLayoutGroup>();
			horizontalLayout.CalculateLayoutInputHorizontal();
		}
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate(layout.GetComponent<RectTransform>());
	}
}
