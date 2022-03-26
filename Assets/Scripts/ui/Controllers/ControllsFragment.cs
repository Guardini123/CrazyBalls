using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllsFragment : MonoBehaviour
{
    [SerializeField] private Button _btnToMenu;

    [SerializeField] private FragmentManager _fragmentManager;

    void Start()
    {
        _btnToMenu.onClick.AddListener(ToMenu);
    }

    private void ToMenu()
	{
        _fragmentManager.OpenFragment("MenuFragment");
        this.gameObject.SetActive(false);
	}
}
