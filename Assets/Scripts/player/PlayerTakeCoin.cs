using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeCoin : MonoBehaviour
{
	public event Action<int> OnCoinGet;

	private int _coinsCount = 0;

	public int CoinsCount => _coinsCount;


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Coin"))
		{
			_coinsCount += other.gameObject.GetComponent<Coin>().TakeCoin();
			OnCoinGet?.Invoke(_coinsCount);
		}
	}
}
