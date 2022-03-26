using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntSaverLoader : MonoBehaviour
{
    public static IntSaverLoader Instance { get; private set; }


	private void Awake()
	{
        if(Instance != null)
		{
            GameObject.Destroy(this.gameObject);
		}

        Instance = this;
        DontDestroyOnLoad(this);
	}


	/// <summary>
	/// �������� ����������
	/// </summary>
	public void ClearSavedData()
	{
		PlayerPrefs.DeleteAll();
	}


	/// <summary>
	/// �������� ����������
	/// </summary>
	/// <param name="key"> ���� </param>
	public void ClearSavedData(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}


	/// <summary>
	/// �������� ����������
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	public void ClearSavedData(string key, string username)
	{
		var bufKey = key + ":" + username;
		PlayerPrefs.DeleteKey(bufKey);
	}


	/// <summary>
	/// ���������, ������� �� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <returns> true- ���� ����������, false - ��� ��� </returns>
	public bool CheckKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}


	/// <summary>
	/// ���������, ������� �� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������ </param>
	/// <returns> true- ���� ����������, false - ��� ��� </returns>
	public bool CheckKey(string key, string username)
	{
		var bufKey = key + ":" + username;
		return CheckKey(bufKey);
	}


	/// <summary>
	/// ��������� �������� int � ������ �� ����� 
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	public void Save(int value, string key)
	{
		PlayerPrefs.SetInt(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// ��������� �������� int � ������ �� ����� � ����� ������������
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	public void Save(int value, string key, string username)
	{
		var bufKey = key + ":" + username;
		Save(value, bufKey);
	}


	/// <summary>
	/// ��������� ��������
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <returns> �������� </returns>
	public int Load(string key)
	{
		return PlayerPrefs.GetInt(key);
	}


	/// <summary>
	/// ��������� ��������
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <returns> �������� </returns>
	public int Load(string key, string username)
	{
		var bufKey = key + ":" + username;
		return Load(bufKey);
	}


	/// <summary>
	/// ��������� �������� �� ����� � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� </returns>
	public bool TryLoad(string key, out int value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = 0;
			return false;
		}

		value = PlayerPrefs.GetInt(key);
		return true;
	}


	/// <summary>
	/// ��������� �������� �� ����� � ����� ������������ � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� � ����� </returns>
	public bool TryLoad(string key, string username, out int value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoad(key, out value, out error);
	}
}
