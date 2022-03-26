using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _fragments;


    public GameObject OpenFragment(string name)
	{
        var fragment = GetFragment(name);
        if (fragment != null)
        {
            fragment.SetActive(true);
            return fragment;
        } 
        else
		{
            return null;
		}
	}

    public void CloseFragment(string name)
	{
        var fragment = GetFragment(name);
        if (fragment != null)
        {
            fragment.SetActive(false);
        }
    }

    public GameObject GetFragment(string name)
	{
        foreach (var fragment in _fragments)
        {
            if (fragment.name.Equals(name))
            {
                return fragment;
            }
        }

        return null;
    }
}
