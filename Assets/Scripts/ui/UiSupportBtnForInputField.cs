using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Button))]
public class UiSupportBtnForInputField : MonoBehaviour
{
    [SerializeField] private string _textToIF;
    private TMP_InputField _targetIF;
	[SerializeField] private TMP_Text _btnText;


	/// <summary>
	/// текст кнопки
	/// </summary>
	public string BtnText { 
		get 
		{
			return _btnText.text;
		}
		set 
		{
			_btnText.text = value;
		} 
	}


	/// <summary>
	/// Что кнопка отправит в текстовое поле
	/// </summary>
	public string TextToIf {
		get 
		{
			return _textToIF;
		} 
		private set 
		{
			_textToIF = value;
		} 
	}


	private void Start()
	{
		this.GetComponent<Button>().onClick.AddListener(OnClick);
	}


	public void OnClick()
	{
		_targetIF.text = _textToIF;
	}


	public void Init(TMP_InputField inputField)
	{
		_targetIF = inputField;
	}


	public void SetTexts(string btnText, string ifText)
	{
		BtnText = btnText;
		TextToIf = ifText;
	}
}
