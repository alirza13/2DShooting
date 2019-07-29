using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private string CoinTag = "Coin";
    private float startTime;
    private float minTime = 10f, maxTime = 20f;
    private float minXLocation = -8f, maxXLocation = 8f;

    private void Start()
    {
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime > Random.Range(minTime,maxTime))
        {
            startTime = 0;
            ObjectPooler.Instance.SpawnFromPool(CoinTag, new Vector2(Random.Range(minXLocation, maxXLocation), transform.position.y), Quaternion.identity);
        }
    }

}
