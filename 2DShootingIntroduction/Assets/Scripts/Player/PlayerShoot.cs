using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Transform bulletSpawnPlace;
    private string FireTag = "Fire";
    private float startTime;

    private void Awake()
    {
        bulletSpawnPlace = transform.GetChild(0);
    }

    private void Start()
    {
        startTime = 0;
    }

    private void Update()
    {
        startTime += Time.deltaTime;
    }

    public void CreateAndFireBullet()
    {
        if (startTime > 1.5f)
        {
            startTime = 0;
            GameObject fireExplosion = ObjectPooler.Instance.SpawnFromPool(FireTag, bulletSpawnPlace.position, Quaternion.identity);
            fireExplosion.SetActive(false);
        }

    }

}
