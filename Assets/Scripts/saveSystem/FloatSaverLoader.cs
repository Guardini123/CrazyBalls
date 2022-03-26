using System.Collections;
using UnityEngine;


public class FloatSaverLoader : MonoBehaviour
{

	public static FloatSaverLoader Instance { get; private set; }


	private void Awake()
	{
		if (Instance != null)
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
	public void Save(float value, string key)
	{
		PlayerPrefs.SetFloat(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// Сохранить значение int в память по ключу и имени пользователя
	/// </summary>
	/// <param name="value"> значение </param>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	public void Save(float value, string key, string username)
	{
		var bufKey = key + ":" + username;
		Save(value, bufKey);
	}


	/// <summary>
	/// Загрузить значение
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <returns> значение </returns>
	public float Load(string key)
	{
		return PlayerPrefs.GetFloat(key);
	}


	/// <summary>
	/// Загрузить значение
	/// </summary>
	/// <param name="key"> ключ </param>
	/// <param name="username"> имя пользователя </param>
	/// <returns> значение </returns>
	public float Load(string key, string username)
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
	public bool TryLoad(string key, out float value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = 0;
			return false;
		}

		value = PlayerPrefs.GetFloat(key);
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
	public bool TryLoad(string key, string username, out float value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoad(key, out value, out error);
	}
}
