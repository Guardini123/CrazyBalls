using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _coinPrefabsToSpawn = new List<GameObject>();

    private List<Coin> _coinInstances = new List<Coin>();

    private CoinsController _coinsController;


    public void InitCoin(CoinsController coinsController)
	{
        _coinsController = coinsController;


        foreach (var coinPrefab in _coinPrefabsToSpawn)
        {
            var newCoin = GameObject.Instantiate(coinPrefab, this.transform.position, this.transform.rotation, this.transform).GetComponent<Coin>();

            _coinInstances.Add(newCoin);
            newCoin.Init(_coinsController);
            newCoin.SetActiveCoin(false);
        }
	}


    public void SpawnCoin()
	{
        foreach(var coin in _coinInstances)
		{
            coin.SetActiveCoin(false);
		}

        var nextCoin = Random.Range(0, _coinInstances.Count);
        _coinInstances[nextCoin].SetActiveCoin(true);
	}
}
