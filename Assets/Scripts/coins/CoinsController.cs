using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    private List<CoinSpawner> _coinSpawners = new List<CoinSpawner>();

    private int _coinSpawnersCount;

    private int _lastCoinId;

    private int _coinsWasSpawned;


	void Start()
    {
        _coinsWasSpawned = 0;

        _lastCoinId = -1;
        _coinSpawnersCount = this.transform.childCount;
        for(int i = 0; i < _coinSpawnersCount; i++)
		{
            var coinSpawner = this.transform.GetChild(i).GetComponent<CoinSpawner>();
            _coinSpawners.Add(coinSpawner);
            coinSpawner.InitCoin(this);
        }

        SpawnNextCoin();
    }


    public void SpawnNextCoin()
	{
        _coinsWasSpawned++;

        var _coinId = Random.Range(0, _coinSpawnersCount);
        while(_coinId == _lastCoinId) {
            _coinId = Random.Range(0, _coinSpawnersCount);
        }

        _coinSpawners[_coinId].SpawnCoin();
        _lastCoinId = _coinId;
	}
}
