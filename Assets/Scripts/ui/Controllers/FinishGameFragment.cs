using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class FinishGameFragment : MonoBehaviour
{
    [SerializeField] private Button _btnToMenu;
    [SerializeField] private GameObject _firstWin;
    [SerializeField] private GameObject _secondWin;
    [SerializeField] private GameObject _allWin;

    [SerializeField] private PlayerTakeCoin _firstPlayer;
    [SerializeField] private PlayerTakeCoin _secondPlayer;

    [SerializeField] private PostProcessProfile _postProcess;

    // Start is called before the first frame update
    void Start()
    {
        _btnToMenu.onClick.AddListener(ToMenu);
    }

	private void OnEnable()
	{
        _firstWin.SetActive(false);
        _secondWin.SetActive(false);
        _allWin.SetActive(false);

        if (_firstPlayer.CoinsCount > _secondPlayer.CoinsCount)
		{
            _firstWin.SetActive(true);
            _firstWin.GetComponent<ObjectScaleAnimation>().StartAnim();
        }
        else if(_firstPlayer.CoinsCount < _secondPlayer.CoinsCount)
		{
            _secondWin.SetActive(true);
            _secondWin.GetComponent<ObjectScaleAnimation>().StartAnim();
        }
        else if(_firstPlayer.CoinsCount == _secondPlayer.CoinsCount)
		{
            _allWin.SetActive(true);
            _allWin.GetComponent<ObjectScaleAnimation>().StartAnim();
        }

        _postProcess.GetSetting<DepthOfField>().active = true;
	}

    private void ToMenu()
	{
        SceneManager.LoadScene("MainScene");
	}
}
