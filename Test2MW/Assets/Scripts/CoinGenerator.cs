using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	private float XSize = 6f;
	private float ZSize = 28f;
	public GameObject coinToCollectPrefab;
	public Vector3 instCoinPosition;
	private Transform playerPosition;
	public GameObject currentCoin;
	public void AddCoinToMap()
	{
		RandomPos();
		currentCoin = Instantiate(coinToCollectPrefab, instCoinPosition, Quaternion.Euler(-90,0,0));
	}

	public void DestroyCoin()
	{
		Destroy(currentCoin);
	}
	void RandomPos()
	{
		instCoinPosition = transform.position + new Vector3(Random.Range(-XSize, XSize), 0.55f, Random.Range(-ZSize, ZSize));
	}


	private void Start()
	{
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
		AddCoinToMap();
	}
}

