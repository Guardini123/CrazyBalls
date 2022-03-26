using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
	private CoinsController _coinsController;

	[SerializeField] private int _coins;
	[SerializeField] private ParticleSystem _particleSystem;
	
	[Space]
	[SerializeField] private MeshRenderer _meshRenderer;
	[SerializeField] private BoxCollider _boxCollider;

	[Space]
	[SerializeField] private AudioClip _takeSound;
	private AudioSource _audio;

	public int Coins => _coins;


	private void Start()
	{
		_audio = this.gameObject.GetComponent<AudioSource>();
	}


	public void Init(CoinsController coinsController)
	{
		_coinsController = coinsController;
	}


	public int TakeCoin()
	{
		_particleSystem.Play();
		_audio.PlayOneShot(_takeSound);
		SetActiveCoin(false);
		_coinsController.SpawnNextCoin();
		return _coins;
	}


	public void SetActiveCoin(bool enable)
	{
		_meshRenderer.enabled = enable;
		_boxCollider.enabled = enable;
	}

}
