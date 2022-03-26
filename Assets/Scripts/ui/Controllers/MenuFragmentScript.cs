using UnityEngine;
using TMPro;
using UnityEngine.UI;
using QuantumTek.QuantumUI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class MenuFragmentScript : MonoBehaviour
{
    [SerializeField] private Button _btnExitGame;
    [SerializeField] private Button _btnOpenControlls;

    [SerializeField] private Button _btnStartGame;
    [SerializeField] private UiInputFieldWithSupport _inputFieldTime;
    [SerializeField] private string _keyForSavingTime;

    [SerializeField] private FragmentManager _fragmentManager;

    [SerializeField] private QUI_OptionList mapChanger;
    
    [SerializeField] private PostProcessProfile _postProcess;


    void Start()
    {
        _btnStartGame.onClick.AddListener(StartGame);
        _btnExitGame.onClick.AddListener(ExitGame);
        _btnOpenControlls.onClick.AddListener(OpenControlls);

        _postProcess.GetSetting<DepthOfField>().active = true;
    }


    private void StartGame()
	{
        int timeToPlay = 0;
        if((int.TryParse(_inputFieldTime.InputField.text, out timeToPlay)) && (timeToPlay > 0))
		{
            IntSaverLoader.Instance.Save(timeToPlay, _keyForSavingTime);
            _inputFieldTime.Save();
            SceneManager.LoadScene(mapChanger.option);
        } 
        else
		{
            _inputFieldTime.InputField.text = "Enter integer number!";
		}
        
	}


    private void ExitGame()
	{
        Application.Quit();
	}


    private void OpenControlls()
	{
        _fragmentManager.OpenFragment("ControllsFragment");
        this.gameObject.SetActive(false);
	}
}
