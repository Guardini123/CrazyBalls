using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class InGameFragmentScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;

    [SerializeField] private TMP_Text _coinsFirst;
    [SerializeField] private TMP_Text _coinsSecond;

    [SerializeField] private PlayerTakeCoin _playerFirst;
    [SerializeField] private PlayerTakeCoin _playerSecond;

	[SerializeField] private PostProcessProfile _postProcess;


	private void OnEnable()
	{
		_postProcess.GetSetting<DepthOfField>().active = false;
	}


	private void Start()
    {
        Timer.Instance.OnLastTimeChanged += SetTimeText;

		_playerFirst.OnCoinGet += (int coins) =>
		{
			_coinsFirst.text = "First player: " + coins.ToString();
			_coinsFirst.GetComponent<TextSizeAnimationUi>().StartAnim();
		};

		_playerSecond.OnCoinGet += (int coins) => 
		{
			_coinsSecond.text = "Second player: " + coins.ToString();
			_coinsSecond.GetComponent<TextSizeAnimationUi>().StartAnim();
		};
	}


	public void SetTimeText(int time)
	{
        _timeText.text = "Seconds left : " + time.ToString();
	}
}