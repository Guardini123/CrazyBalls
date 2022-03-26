using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnGameEnd;
    public event Action<int> OnLastTimeChanged;

    public static Timer Instance { get; private set; }

    private float _lastSeconds = 0.0f;
    public float LastSeconds => _lastSeconds;

    private bool _boolStartGame = false;

    [SerializeField] private string _keyForLoadingTime;


    private void Awake()
	{
        Instance = this;
	}


	private void Start()
	{
        var timeForPlay = LoadTime();
        if (timeForPlay != 0) StartGame(timeForPlay);
    }



	void Update()
    {
        if (!_boolStartGame) return;

        _lastSeconds -= Time.deltaTime;
        OnLastTimeChanged?.Invoke((int)_lastSeconds);
        if (LastSeconds <= 0) GameEnd();
    }


    public void StartGame(int time)
	{
        _lastSeconds = time;
        _boolStartGame = true;
	}


    private void GameEnd()
	{
        _boolStartGame = false;
        OnGameEnd?.Invoke();
	}


    private int LoadTime()
    {
        return IntSaverLoader.Instance.Load(_keyForLoadingTime);
    }
}
