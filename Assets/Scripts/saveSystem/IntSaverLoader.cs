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
	/// Отчистка сохранений
	/// </summary>
	public void ClearSavedData()
	{
		PlayerPrefs.DeleteAll();
	}


	/// <summary>
	/// Отчистка сохранений
	/// </summary>
	/// <param name="key"> ключ </param>
	public void ClearSavedData(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}


	/// <summary>
	/// Отчистка сохранений
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void ClearSavedData(string key, string username)
	{
		var bufKey = key + ":" + username;
		PlayerPrefs.DeleteKey(bufKey);
	}


	/// <summary>
	/// Проверить, сохранён ли ключ
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> true- было сохранение, false - ещё нет </returns>
	public bool CheckKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}


	/// <summary>
	/// Проверить, сохранён ли ключ
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя игрока </param>
	/// <returns> true- было сохранение, false - ещё нет </returns>
	public bool CheckKey(string key, string username)
	{
		var bufKey = key + ":" + username;
		return CheckKey(bufKey);
	}


	/// <summary>
	/// Сохранить значение int в память по ключу 
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	public void Save(int value, string key)
	{
		PlayerPrefs.SetInt(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// Сохранить значение int в память по ключу и имени пользователя
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void Save(int value, string key, string username)
	{
		var bufKey = key + ":" + username;
		Save(value, bufKey);
	}


	/// <summary>
	/// Загрузить значение
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> значение </returns>
	public int Load(string key)
	{
		return PlayerPrefs.GetInt(key);
	}


	/// <summary>
	/// Загрузить значение
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <returns> значение </returns>
	public int Load(string key, string username)
	{
		var bufKey = key + ":" + username;
		return Load(bufKey);
	}


	/// <summary>
	/// Загрузить значение по ключу и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> Значение по ключу </returns>
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
	/// Загрузить значение по ключу и имени пользователя и вывести ошибку, если была
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <param name="value"> значение </param>
	/// <param name="error"> ошибка. Если ошибки не было, будет null </param>
	/// <returns> Значение по ключу и имени </returns>
	public bool TryLoad(string key, string username, out int value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoad(key, out value, out error);
	}
}
