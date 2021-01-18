using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int count;
    public GameObject coin;

    void Start()
    {
        for(int i = 0; i < count; i++)
        {
        	Vector3 randomPos = new Vector3(Random.value * 1000 - 500, 0f, Random.value * 1000 - 500);
        	GameObject coins = GameObject.Instantiate(coin, randomPos, Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
