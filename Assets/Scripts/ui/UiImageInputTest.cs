using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class UiImageInputTest : MonoBehaviour
{
	private Image _targetImage;
	private Color32 _startColor;
	[SerializeField] private Color32 _targetColor;
	[SerializeField] private KeyCode _targetKey;


	private void Start()
	{
		_targetImage = this.GetComponent<Image>();
		_startColor = _targetImage.color;
	}



	private void Update()
	{
		if (Input.GetKey(_targetKey))
		{
			MarkImg();
		}

		if (!Input.GetKey(_targetKey))
		{
			UnMarkImg();
		}
	}


	public void MarkImg()
	{
		_targetImage.color = _targetColor;
	}


	public void UnMarkImg()
	{
		_targetImage.color = _startColor;
	}
}
